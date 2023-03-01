using Prototype.Logic.Interactables;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class ForgeObserveUI : ObserveUI<ForgeObserveBehavior>
    {
        [SerializeField] private BotHuntingBehavior _botHuntingBehavior;

        protected override string GetDescription()
        {
            string output = $"Forge - Interact (E)";

            ProductionBuildingBotPlace botPlace = _observeBehavior.ObservedForge.GetComponent<ProductionBuildingBotPlace>();

            if (botPlace.IsEmpty && _botHuntingBehavior.HasAny)
                output += "\n Assign bot (G)";

            return output;
        }
    }
}