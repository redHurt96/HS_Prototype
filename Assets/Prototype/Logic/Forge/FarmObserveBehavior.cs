using System;
using Prototype.Logic.Attributes;
using Prototype.Logic.Extensions;
using Prototype.Logic.Framework.UI;
using Prototype.Logic.Interactables;
using Prototype.Logic.InventoryBehavior;
using Prototype.Scripts.Forge;
using UnityEngine;
using static Prototype.Logic.Framework.UI.Window;

namespace Prototype.Logic.Forge
{
    public class FarmObserveBehavior : ObserveBehavior
    {
        public override bool IsObserve => ObservedFarm != null;
        
        [ReadOnly] public Farm ObservedFarm;
        
        [SerializeField] private Inventory _playerInventory;
        [SerializeField] private BotHuntingBehavior _botHuntingBehavior;
        [SerializeField] private WindowsRouter _windowsRouter;

        protected override Func<GameObject, bool> IsObserveTarget { get; } = 
            target => target.HasComponent<Farm>();
        
        protected override void SetupObservedObject(GameObject target) => 
            ObservedFarm = target.GetComponent<Farm>();

        protected override void ClearObservedObject()
        {
            ObservedFarm = null;
            
            _windowsRouter.Close(WindowName.Farm);
        }

        protected override void Interact(GameObject target) => 
            _windowsRouter.Open(WindowName.Farm, ObservedFarm, _playerInventory);

        protected override void AdditionalInteract(GameObject target)
        {
            ProductionBuildingBotPlace place = target.GetComponent<ProductionBuildingBotPlace>();

            if (place.IsEmpty && _botHuntingBehavior.HasAny) 
                place.SetBot(_botHuntingBehavior.Get());
        }
    }
}