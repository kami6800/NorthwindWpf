using Entities.Models;
using Newtonsoft.Json;
using Services.PhoneValidation;
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

        public bool ValidPhoneNumber(string number)
        {
            string url = $"http://apilayer.net/api/validate?access_key=6ea1e9c3cf840443cd49437c55fae187&number=" + number;
            string json = GetJson(url);
            Numverify num = JsonConvert.DeserializeObject<Numverify>(json);
            return num.Valid;
        }
    }
}

