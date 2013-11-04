using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lombiq.Abstractions.QuickParts;
using Orchard.Environment.Extensions;

namespace Lombiq.Abstractions.Examples.Models
{
    [OrchardFeature("Lombiq.Abstractions.Examples.QuickWidgets")]
    public class CurrencyConverterPart : QuickPart
    {
        public virtual string FromCurrencyCode { get; set; }
        public virtual string ToCurrencyCode { get; set; }
    }
}