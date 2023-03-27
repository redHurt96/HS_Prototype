using Prototype.Logic.Interactables;

namespace Prototype.Logic.Forge
{
    public class QuestItemObserveUI : ObserveUI<QuestItemsObserveBehavior>
    {
        protected override string GetDescription() => 
            $"{_observeBehavior.Item.Description}";
    }
}