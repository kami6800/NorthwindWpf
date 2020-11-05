using Newtonsoft.Json;
using System;
using System.Net;

namespace Services
{
    public class ValidationWebService
    {
        private string GetJson(string url)
        {
            string json;
            using(WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }
            return json;
        }

        //public bool IsEmailValid(string email)
        //{

        //}

        public string ApplyLanguageFilter(string text)
        {
            string url = "https://www.purgomalum.com/service/json?text=" + text;
            string json = GetJson(url);
            PurgoMalum purgo = JsonConvert.DeserializeObject<PurgoMalum>(json);
            return purgo.Result;
        }
    }
}
