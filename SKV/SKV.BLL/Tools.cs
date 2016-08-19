using System;
using System.Globalization;
using System.Timers;

namespace SKV.BLL
{
    public static class Tools
    {
        public static decimal ParseDecimal(string val) => decimal.Parse(val, CultureInfo.InvariantCulture);

        public static Timer CreatePeriodicProcess(ElapsedEventHandler process, double period)
        {
            var timer = new Timer(period);

            timer.Elapsed += process;
            timer.Start();

            return timer;
        }

        public static decimal Inverse(decimal val) => 1.0M / val;
    }
}
