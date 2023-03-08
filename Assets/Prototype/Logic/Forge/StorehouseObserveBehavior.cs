using System;
using Prototype.Logic.Attributes;
using Prototype.Logic.Craft;
using Prototype.Logic.Extensions;
using Prototype.Logic.Interactables;
using Prototype.Logic.InventoryBehavior;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class StorehouseObserveBehavior : ObserveBehavior
    {
        public override bool IsObserve => ObservedStoreHouse != null;

        [ReadOnly] public Inventory ObservedStoreHouse;

        [SerializeField] private StorehouseWindow _storehouseWindow;
        [SerializeField] private Inventory _playerInventory;

        protected override Func<GameObject, bool> IsObserveTarget { get; } = target =>
            target.HasComponent<Inventory>()
            && target.TryGetComponent(out Building building)
            && building.Name.ToLower().Contains("storehouse");
        
        protected override void SetupObservedObject(GameObject target) => 
            ObservedStoreHouse = target.GetComponent<Inventory>();

        protected override void ClearObservedObject()
        {
            ObservedStoreHouse = null;
            
            if (_storehouseWindow.gameObject.activeSelf)
                _storehouseWindow.Hide();
        }

        protected override void Interact(GameObject target) => 
            _storehouseWindow.Show(ObservedStoreHouse, _playerInventory);
    }
}