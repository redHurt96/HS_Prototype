using Prototype.Logic.Items;

namespace Prototype.Logic.Forge
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