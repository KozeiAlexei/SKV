using System;

using SKV.DAL.Abstract.Entity;

namespace SKV.DAL.Abstract.Model.CurrencyModel
{
    public interface ICurrencyRate<TKey> : IEntity<TKey>, ICloneableFrom<ICurrencyRate<TKey>>
    {
        decimal Sum { get; set; }

        decimal Sale { get; set; }

        decimal Purchase { get; set; }


        string Ticker { get; set; }

        bool Commission { get; set; }

        DateTime LastUpdate { get; set; }
    }
}
