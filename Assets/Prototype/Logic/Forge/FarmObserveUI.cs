using Prototype.Logic.Interactables;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class FarmObserveUI : ObserveUI<FarmObserveBehavior>
    {
        [SerializeField] private BotHuntingBehavior _botHuntingBehavior;

        protected override string GetDescription()
        {
            string output = $"Farm - Interact (E)";

            ProductionBuildingBotPlace botPlace = _observeBehavior.ObservedFarm.GetComponent<ProductionBuildingBotPlace>();

            if (botPlace.IsEmpty && _botHuntingBehavior.HasAny)
                output += "\n Assign bot (G)";

            return output;
        }
    }
}