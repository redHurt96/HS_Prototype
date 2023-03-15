using Prototype.Logic.Interactables;

namespace Prototype.Logic.Forge
{
    public class MineFieldsObserveUI : ObserveUI<MineFieldObserveBehavior>
    {
        protected override string GetDescription() => 
            $"{_observeBehavior.MineFieldItemView.Name} - Mine (LMB)";
    }
}