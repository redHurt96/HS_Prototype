using Prototype.Logic.Interactables;

namespace Prototype.Logic.Forge
{
    public class BushObserveUI : ObserveUI<BushObserveBehavior>
    {
        protected override string GetDescription() => 
            $"{_observeBehavior.Bush.Name} - Collect (LMB)";
    }
}