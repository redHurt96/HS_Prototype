using Prototype.Scripts.Interactables;

namespace Prototype.Scripts.InventoryBehavior
{
    public class CraftProcess
    {
        public int ClickCount;
        
        public readonly Item Target;

        public CraftProcess(Item target, int clickCount)
        {
            Target = target;
            ClickCount = clickCount;
        }
    }
}