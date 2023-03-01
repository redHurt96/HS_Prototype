using System;
using Prototype.Logic.Attributes;
using Prototype.Logic.Extensions;
using Prototype.Logic.Interactables;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class ForgeObserveBehavior : ObserveBehavior
    {
        public override bool IsObserve => ObservedForge != null;

        [ReadOnly] public Forge ObservedForge;

        [SerializeField] private ForgeWindow _forgeWindow;
        [SerializeField] private InventoryBehavior.Inventory _playerInventory;
        [SerializeField] private BotHuntingBehavior _botHuntingBehavior;

        protected override Func<GameObject, bool> IsObserveTarget { get; } = target =>
            target.HasComponent<Forge>();

        protected override void SetupObservedObject(GameObject target) => 
            ObservedForge = target.GetComponent<Forge>();

        protected override void ClearObservedObject()
        {
            ObservedForge = null;
            
            if (_forgeWindow.gameObject.activeSelf)
                _forgeWindow.Hide();
        }

        protected override void Interact(GameObject target) => 
            _forgeWindow.Show(ObservedForge, _playerInventory);

        protected override void AdditionalInteract(GameObject target)
        {
            ProductionBuildingBotPlace place = target.GetComponent<ProductionBuildingBotPlace>();

            if (place.IsEmpty && _botHuntingBehavior.HasAny) 
                place.SetBot(_botHuntingBehavior.Get());
        }
    }
}