using System;
using Prototype.Logic.Attributes;
using Prototype.Logic.Extensions;
using Prototype.Logic.Framework.UI;
using Prototype.Logic.Interactables;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class ForgeObserveBehavior : ObserveBehavior
    {
        public override bool IsObserve => ObservedForge != null;

        [ReadOnly] public Forge ObservedForge;

        [SerializeField] private InventoryBehavior.Inventory _playerInventory;
        [SerializeField] private BotHuntingBehavior _botHuntingBehavior;
        [SerializeField] private WindowsRouter _windowsRouter;

        protected override Func<GameObject, bool> IsObserveTarget { get; } = target =>
            target.HasComponent<Forge>();

        protected override void SetupObservedObject(GameObject target) => 
            ObservedForge = target.GetComponent<Forge>();

        protected override void ClearObservedObject()
        {
            ObservedForge = null;
            
            _windowsRouter.Close(WindowName.Forge);
        }

        protected override void Interact(GameObject target) => 
            _windowsRouter.Open(WindowName.Forge, ObservedForge, _playerInventory);

        protected override void AdditionalInteract(GameObject target)
        {
            ProductionBuildingBotPlace place = target.GetComponent<ProductionBuildingBotPlace>();

            if (place.IsEmpty && _botHuntingBehavior.HasAny) 
                place.SetBot(_botHuntingBehavior.Get());
        }
    }
}