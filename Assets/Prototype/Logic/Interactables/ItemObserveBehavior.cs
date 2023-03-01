using System;
using Prototype.Logic.Attributes;
using Prototype.Logic.Extensions;
using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.Interactables
{
    public class ItemObserveBehavior : ObserveBehavior
    {
        public override bool IsObserve => !ObservedItemCell.IsEmpty;
        
        [ReadOnly] public ItemCell ObservedItemCell;

        [SerializeField] private InventoryBehavior.Inventory _inventory;
        
        protected override Func<GameObject, bool> IsObserveTarget { get; } = target =>
            target.HasComponent<ItemView>();

        protected override void SetupObservedObject(GameObject target) =>
            ObservedItemCell = target.GetComponent<ItemView>().ItemCell;

        protected override void ClearObservedObject() => 
            ObservedItemCell = default;

        protected override void Interact(GameObject target)
        {
            _inventory.Add(ObservedItemCell);
            Destroy(target);
        }
    }
}