using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;

using SKV.BLL.Abstract.CurrencyRates;
using SKV.ML.Concrete.Model.CurrencyModel;

namespace SKV.BLL.CurrencyRates
{
    public class ForexParser : IForexParser
    {
        private const string FOREX_OIL_URI = "http://www.forexpf.ru/_informer_/comod.php?id=23";
        private const string FOREX_EUR_TO_USD = "http://informers.forexpf.ru/forex.php?id=4";
        private const string FOREX_RUB_USD_EUR_URI = "http://informers.forexpf.ru/export/win/euusrub.js";
        private const string FOREX_OTHER_CURRENCIES = "http://informers.forexpf.ru/forex.php?id=124579";

        private const string OIL_LITE = "Нефть Лайт";
        private const string OIL_BRENT = "Нефть Brent";
        private const string EUR_USD_TICKER = "EUR/USD";

        public IEnumerable<CurrencyRate> ParseOil()
        {
            var html = SafePageDownload(FOREX_OIL_URI);

            html = html.Substring(html.IndexOf("if(flg==1){") + 11);
            html = html.Substring(0, html.IndexOf("if(document.getElementById(\"ccomtm\"))"));

            html = html.Replace("cbrentb", OIL_BRENT);
            html = html.Replace("clightb", OIL_LITE);

            return ParseRates(html.Split(';').Take(4).ToArray(), (bid, start, end) => bid.Substring(start + 1, end - start - 1));
        }

        public IEnumerable<CurrencyRate> ParseEuroToUsd()
        {
            var html = SafePageDownload(FOREX_EUR_TO_USD);

            html = html.Substring(html.IndexOf(")||1){"));
            html = html.Substring(0, html.IndexOf("document.getElementById(\"frxtm\")"));

            html = html.Replace("euusb", EUR_USD_TICKER);

            return ParseRates(html.Split(';').Take(2).ToArray(), (bid, start, end) => bid.Substring(start + 1, end - start - 1));
        }

        public IEnumerable<CurrencyRate> ParseEuroUsdRub() => ParseRates(SafePageDownload(FOREX_RUB_USD_EUR_URI).Replace('=', '"').Replace(';', '"').Split('\n').Skip(4).Take(4).ToArray(), (bid, start, end) => bid.Substring(start + 1, end - start - 4).Insert(3, "/").ToUpper());
        public IEnumerable<CurrencyRate> ParseOtherCurrencies()
        {
            var html = SafePageDownload(FOREX_OTHER_CURRENCIES);

            html = html.Substring(html.IndexOf("|1)") + 4);
            html = html.Substring(0, html.Length - 3);

            var dirty_rates = html.Split(';');
            dirty_rates = dirty_rates.Take(dirty_rates.Count() - 1).ToArray();

            return ParseRates(dirty_rates, (bid, start, end) => bid.Substring(start + 1, end - start - 2).Insert(2, "/").ToUpper());
        }

        private IEnumerable<CurrencyRate> ParseRates(string[] dirty_rates, Func<string, int, int, string> ticker_parse_func)
        {
            for (int i = 0; i < dirty_rates.Count(); i += 2)
                yield return GetCurrencyRate(dirty_rates.ElementAt(i), dirty_rates.ElementAt(i + 1), ticker_parse_func);
        }

        private CurrencyRate GetCurrencyRate(string bid, string ask, Func<string, int, int, string> func)
        {
            var ticker_start = bid.IndexOf('"');
            var ticker_end = bid.IndexOf('"', ticker_start + 1);

            var bid_val_start = bid.IndexOf('"', ticker_end + 1) + 1;
            var bid_val_end = bid.IndexOf('"', bid_val_start + 1) - 1;

            var ask_val_start = ask.IndexOf('"', ticker_end + 1) + 1;
            var ask_val_end = ask.IndexOf('"', ask_val_start + 1) - 1;

            return new CurrencyRate()
            {
                Sale = Tools.ParseDecimal(ask.Substring(ask_val_start, ask_val_end - ask_val_start + 1)),
                Ticker = func(bid, ticker_start, ticker_end),
                Purchase = Tools.ParseDecimal(bid.Substring(bid_val_start, bid_val_end - bid_val_start + 1))
            };
        }

        private string SafePageDownload(string uri)
        {
            var html = default(string);
            var client = new WebClient();
            lock (client)
            {
                html = client.DownloadString(uri);
            }

            return html;
        }
    }
}
