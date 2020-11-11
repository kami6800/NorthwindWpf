using System;
using System.Collections.Generic;
using System.Text;

namespace Services.PhoneValidation
{
    public class Numverify
    {
        public bool Valid { get; set; }
        public string Local_format { get; set; }
        public string Intl_format { get; set; }
        public string Country_code { get; set; }
        public string Country_name { get; set; }
        public string Location { get; set; }
        public string Carrier { get; set; }
        public string Line_type { get; set; }
    }
}
