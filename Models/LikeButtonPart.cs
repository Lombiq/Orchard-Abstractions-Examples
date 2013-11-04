using Lombiq.Abstractions.QuickParts;
using Orchard.Environment.Extensions;

namespace Lombiq.Abstractions.Examples.Models
{
    [OrchardFeature("Lombiq.Abstractions.Examples.QuickParts")]
    public class LikeButtonPart : QuickPart
    {
        public virtual bool IsEnabled { get; set; }
    }
}