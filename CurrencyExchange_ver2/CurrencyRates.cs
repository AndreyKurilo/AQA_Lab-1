using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_ver2
{
    public class CurrencyRates
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

        public async Task<double> GetRates()
        {
            string urlUSD = "https://www.nbrb.by/api/exrates/rates/431";
            string urlEUR = "https://www.nbrb.by/api/exrates/rates/451";
            string urlRUB = "https://www.nbrb.by/api/exrates/rates/456";

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://www.nbrb.by/api/exrates/rates/451");

            var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            var ratesDto = JsonConvert.DeserializeObject<RatesDto>(json);

            return ratesDto.CurOfficialRate;
            //using (var webClient = new WebClient())
            //{
            //    var responseUSD = webClient.DownloadString(urlUSD);
            //    var responseEUR = webClient.DownloadString(urlEUR);
            //    var responseRUB = webClient.DownloadString(urlRUB);
            //}
        }
    }
}
