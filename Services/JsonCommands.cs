using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Services
{
    public abstract class JsonCommands
    {
        protected string GetJson(string url)
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }
            return json;
        }
    }
}
