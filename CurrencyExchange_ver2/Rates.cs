using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange_ver2
{
    class Rates
    {
        double rateUSD, rateEUR, rateRUB;
        public void SetUSDrate(string rate)
        {
            rateUSD = Double.Parse(rate);
        }

        public void SetEURrate(string rate)
        {
            rateEUR = Double.Parse(rate);
        }

        public void SetRUBrate(string rate)
        {
            rateRUB = Double.Parse(rate) / 100;
        }

        public double getUSD()
        {
            return rateUSD;
        }

        public double getEUR()
        {
            return rateEUR;
        }

        public double getRUB()
        {
            return rateRUB;
        }
    }
}
