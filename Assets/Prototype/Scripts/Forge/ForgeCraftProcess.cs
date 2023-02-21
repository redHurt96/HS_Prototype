using Prototype.Scripts.Items;

namespace Prototype.Scripts.Forge
{
    public class ForgeCraftProcess
    {
        public int ClickCount;
        
        public readonly Item Target;

        public ForgeCraftProcess(Item target, int clickCount)
        {
            Target = target;
            ClickCount = clickCount;
        }
    }
}