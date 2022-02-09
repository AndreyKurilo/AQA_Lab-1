using System;
using System.Collections.Generic;
using System.Net;
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

        public void GetRates()
        {
            string urlUSD = "https://www.nbrb.by/api/exrates/rates/431";
            string urlEUR = "https://www.nbrb.by/api/exrates/rates/451";
            string urlRUB = "https://www.nbrb.by/api/exrates/rates/456";


            using (var webClient = new WebClient())
            {
                var responseUSD = webClient.DownloadString(urlUSD);
                var responseEUR = webClient.DownloadString(urlEUR);
                var responseRUB = webClient.DownloadString(urlRUB);
            }
        }
    }
}
