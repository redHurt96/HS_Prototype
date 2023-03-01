using Prototype.Logic.Interactables;

namespace Prototype.Logic.Forge
{
    public class StorehouseObserveUI : ObserveUI<StorehouseObserveBehavior>
    {
        protected override string GetDescription() => 
            $"Storehouse - Interact (E)";
    }
}