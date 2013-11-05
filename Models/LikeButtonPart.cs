using Lombiq.Abstractions.QuickParts;
using Orchard.Environment.Extensions;

namespace Lombiq.Abstractions.Examples.Models
{
    /*
     * This is how a quick part looks. This is the model of your data, a plain class. Only two things to note here:
     * - Quick parts should derive from QuickPart
     * - All properties that you want to be persisted should be public and virtual. In turn every public virtual property will be persisted
     *   in the DB. Storage is automatically handled by the framework.
     *   
     * Quick parts are automatically set up as attachable.
     */
    [OrchardFeature("Lombiq.Abstractions.Examples.QuickParts")]
    public class LikeButtonPart : QuickPart
    {
        public virtual bool IsEnabled { get; set; }
    }
}