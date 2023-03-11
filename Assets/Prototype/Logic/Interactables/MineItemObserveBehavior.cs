using System;
using Prototype.Logic.Attributes;
using Prototype.Logic.Extensions;
using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.Interactables
{
    public class MineItemObserveBehavior : ObserveBehavior
    {
        public override bool IsObserve => MineItemView != null;
        
        [ReadOnly] public MineItemView MineItemView;

        [SerializeField] private InventoryBehavior.Inventory _inventory;
        [SerializeField] private CharacterEquipment _characterEquipment;
        
        protected override Func<GameObject, bool> IsObserveTarget { get; } = target =>
            target.HasComponent<MineItemView>();

        protected override void SetupObservedObject(GameObject target) =>
            MineItemView = target.GetComponent<MineItemView>();

        protected override void ClearObservedObject() => 
            MineItemView = null;

        protected override void Interact(GameObject target) => 
            MineItemView
                .Punch(_characterEquipment.GetPunchForce(MineItemView), _inventory);
    }
}