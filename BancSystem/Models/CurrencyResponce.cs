using System;
using System.Collections.Generic;
using System.Text;

namespace BancSystem.Models
{
    public class CurrencyResponce
    {
        public bool Seccess { get; set; }
        public string Terms { get; set; }
        public string Privacy { get; set; }
        public int TimeStamp { get; set; }
        public string Source { get; set; }
        public Dictionary<string, double> Quotes { get; set; }
    }
}
