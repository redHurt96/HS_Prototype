using System;
using Prototype.Logic.Attributes;
using Prototype.Logic.Extensions;
using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.Interactables
{
    public class BushObserveBehavior : ObserveBehavior
    {
        public override bool IsObserve => Bush != null;
        
        [ReadOnly] public Bush Bush;

        [SerializeField] private InventoryBehavior.Inventory _inventory;
        
        protected override Func<GameObject, bool> IsObserveTarget { get; } = target =>
            target.HasComponent<Bush>();

        protected override void SetupObservedObject(GameObject target) =>
            Bush = target.GetComponent<Bush>();

        protected override void ClearObservedObject() => 
            Bush = null;

        protected override void Interact(GameObject target) => 
            Bush.Pickup(_inventory);
    }
}