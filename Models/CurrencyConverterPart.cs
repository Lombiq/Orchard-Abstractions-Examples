using Lombiq.Abstractions.QuickWidgets;
using Orchard.Environment.Extensions;

namespace Lombiq.Abstractions.Examples.Models
{
    /*
     * Quick widgets also revolve around their part. The same goes as for quick parts, only that models should derive from QuickWidgetPart.
     * 
     * For every quick widget part there will be a corresponding widget created (named Currency Converter Widget here).
     */
    [OrchardFeature("Lombiq.Abstractions.Examples.QuickWidgets")]
    public class CurrencyConverterPart : QuickWidgetPart
    {
        public virtual string FromCurrencyCode { get; set; }
        public virtual string ToCurrencyCode { get; set; }
    }
}