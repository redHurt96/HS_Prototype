using Prototype.Logic.Interactables;

namespace Prototype.Logic.Forge
{
    public class MineItemsObserveUI : ObserveUI<MineItemObserveBehavior>
    {
        protected override string GetDescription() => 
            $"{_observeBehavior.MineItemView.Name} - Punch (LMB)";
    }
}