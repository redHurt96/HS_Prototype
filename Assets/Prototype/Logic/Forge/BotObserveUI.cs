using Prototype.Logic.Interactables;

namespace Prototype.Logic.Forge
{
    public class BotObserveUI : ObserveUI<BotObserveBehavior>
    {
        protected override string GetDescription() => 
            $"Bot - Hunt (E)";
    }
}