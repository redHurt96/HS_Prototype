using System;
using Prototype.Logic.Attributes;
using Prototype.Logic.Extensions;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using Prototype.Logic.Quests;
using UnityEngine;

namespace Prototype.Logic.Interactables
{
    public class QuestItemsObserveBehavior : ObserveBehavior
    {
        private static QuestsBehavior QuestsBehavior;
        
        public override bool IsObserve => Item != null;
        
        [ReadOnly] public QuestItem Item;

        [SerializeField] private QuestsBehavior _questsBehavior;
        [SerializeField] private Inventory _inventory;

        private void Start() => 
            QuestsBehavior ??= _questsBehavior;

        protected override Func<GameObject, bool> IsObserveTarget { get; } = target =>
            target.TryGetComponent(out QuestItem item)
            && QuestsBehavior.HasAny
            && QuestsBehavior.CompareKey(item.QuestKey);

        protected override void SetupObservedObject(GameObject target) =>
            Item = target.GetComponent<QuestItem>();

        protected override void ClearObservedObject() => 
            Item = null;

        protected override void Interact(GameObject target)
        {
            if (_questsBehavior.HasAny && _questsBehavior.CompareKey(Item.QuestKey))
            {
                _questsBehavior.Receive(Item.QuestKey);

                if (Item is QuestPickableItem pickableItem)
                {
                    _inventory.Add(pickableItem.ItemCell);
                    Destroy(target);
                }
            }
        }
    }
}