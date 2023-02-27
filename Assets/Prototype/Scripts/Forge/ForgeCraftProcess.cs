using Prototype.Scripts.Items;

namespace Prototype.Scripts.Forge
{
    public class ForgeCraftProcess
    {
        public int ClickCount;
        
        public readonly ItemCell Target;

        public ForgeCraftProcess(ItemCell target, int clickCount)
        {
            Target = target;
            ClickCount = clickCount;
        }
    }
}