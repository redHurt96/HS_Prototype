using Prototype.Logic.Items;

namespace Prototype.Logic.Interactables
{
    public class ItemsObserveUI : ObserveUI<ItemObserveBehavior>
    {
        protected override string GetDescription()
        {
            ItemCell cell = _observeBehavior.ObservedItemCell;
            return $"{cell.ItemName} ({cell.Count}) - Pickup (E)";
        }
    }
}