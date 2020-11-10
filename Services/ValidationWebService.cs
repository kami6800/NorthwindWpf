using Entities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace Services
{
    public class ValidationWebService : JsonCommands
    {
        public string ApplyLanguageFilter(string text)
        {
            string url = "https://www.purgomalum.com/service/json?text=" + text;
            string json = GetJson(url);
            PurgoMalum purgo = JsonConvert.DeserializeObject<PurgoMalum>(json);
            return purgo.Result;
        }
    }
}
