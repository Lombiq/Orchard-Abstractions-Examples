using System.Collections.Generic;
using System.Net;
using Lombiq.Abstractions.Examples.Models;
using Lombiq.Abstractions.QuickParts;
using Orchard.Environment.Extensions;

namespace Lombiq.Abstractions.Examples.QuickPartLogics
{
    /*
     * Quick parts can have pieces of logic defined for them (like code behind files).
     */
    [OrchardFeature("Lombiq.Abstractions.Examples.QuickWidgets")]
    public class CurrencyConverterPartLogic : IQuickPartLogic<CurrencyConverterPart>
    {
        // This is called when the part is displayed.
        public IEnumerable<KeyValuePair<string, object>> ComputeDisplayParameters(CurrencyConverterPart part)
        {
            var context = new Dictionary<string, object>();

            if (string.IsNullOrEmpty(part.FromCurrencyCode) || string.IsNullOrEmpty(part.ToCurrencyCode)) return context;

            using (var wc = new WebClient())
            {
                var csv = wc.DownloadString("http://download.finance.yahoo.com/d/quotes.csv?s=" + part.FromCurrencyCode + part.ToCurrencyCode + "=X&f=nl1d1t1");
                var exchangeRate = decimal.Parse(csv.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture);
                // We can add parameters to the template's scope like this. This value will be reachable from the template as Model.ExchangeRate.
                context["ExchangeRate"] = exchangeRate;
            }

            return context;
        }
    }
}