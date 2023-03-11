using System;
using Prototype.Logic.Attributes;
using Prototype.Logic.Craft;
using Prototype.Logic.Extensions;
using Prototype.Logic.Framework.UI;
using Prototype.Logic.Interactables;
using Prototype.Logic.InventoryBehavior;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class StorehouseObserveBehavior : ObserveBehavior
    {
        public override bool IsObserve => ObservedStoreHouse != null;

        [ReadOnly] public Inventory ObservedStoreHouse;

        [SerializeField] private Inventory _playerInventory;
        [SerializeField] private WindowsRouter _windowsRouter;

        protected override Func<GameObject, bool> IsObserveTarget { get; } = target =>
            target.HasComponent<Inventory>()
            && target.TryGetComponent(out Building building)
            && building.Name.ToLower().Contains("storehouse");
        
        protected override void SetupObservedObject(GameObject target) => 
            ObservedStoreHouse = target.GetComponent<Inventory>();

        protected override void ClearObservedObject()
        {
            ObservedStoreHouse = null;
            
            _windowsRouter.Close(WindowName.Storehouse);
        }

        protected override void Interact(GameObject target) =>
            _windowsRouter.Open(WindowName.Storehouse, ObservedStoreHouse, _playerInventory);
    }
}