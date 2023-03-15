using System;
using Prototype.Logic.Attributes;
using Prototype.Logic.Extensions;
using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.Interactables
{
    public class MineFieldObserveBehavior : ObserveBehavior
    {
        public override bool IsObserve => MineFieldItemView != null;
        
        [ReadOnly] public MineFieldItemView MineFieldItemView;

        [SerializeField] private InventoryBehavior.Inventory _inventory;
        
        protected override Func<GameObject, bool> IsObserveTarget { get; } = target =>
            target.HasComponent<MineFieldItemView>();

        protected override void SetupObservedObject(GameObject target) =>
            MineFieldItemView = target.GetComponent<MineFieldItemView>();

        protected override void ClearObservedObject() => 
            MineFieldItemView = null;

        protected override void Interact(GameObject target) => 
            MineFieldItemView
                .Punch(_inventory);
    }
}