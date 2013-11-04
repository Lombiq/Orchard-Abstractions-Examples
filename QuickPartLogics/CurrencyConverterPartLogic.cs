using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Lombiq.Abstractions.Examples.Models;
using Lombiq.Abstractions.QuickParts;
using Orchard.Environment.Extensions;

namespace Lombiq.Abstractions.Examples.QuickPartLogics
{
    [OrchardFeature("Lombiq.Abstractions.Examples.QuickWidgets")]
    public class CurrencyConverterPartLogic : IQuickPartLogic<CurrencyConverterPart>
    {
        public IEnumerable<KeyValuePair<string, object>> ComputeDisplayParameters(CurrencyConverterPart part)
        {
            var context = new Dictionary<string, object>();

            if (string.IsNullOrEmpty(part.FromCurrencyCode) || string.IsNullOrEmpty(part.ToCurrencyCode)) return context;

            using (var wc = new WebClient())
            {
                var csv = wc.DownloadString("http://download.finance.yahoo.com/d/quotes.csv?s=" + part.FromCurrencyCode + part.ToCurrencyCode + "=X&f=nl1d1t1");
                var exchangeRate = decimal.Parse(csv.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture);
                context["ExchangeRate"] = exchangeRate;
            }

            return context;
        }
    }
}