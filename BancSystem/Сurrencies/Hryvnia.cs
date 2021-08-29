using System;
using System.Collections.Generic;
using System.Text;

namespace BancSystem.Currencies
{
    public class Hryvnia : CurrencyType
    {
        public Hryvnia()
        {
            PriceCurrency = 0.037;
            NameCurrency = "Гривна";
        }
    }
}
