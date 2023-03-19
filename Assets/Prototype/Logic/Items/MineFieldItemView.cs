using Prototype.Logic.Attributes;
using Prototype.Logic.InventoryBehavior;
using UnityEngine;

namespace Prototype.Logic.Items
{
    public class MineFieldItemView : MonoBehaviour
    {
        public string Name => _itemFromSinglePunch.ItemName;
        public bool IsBusy => _isBusy;

        [SerializeField] private ItemCell _itemFromSinglePunch;
        [SerializeField, ReadOnly] private bool _isBusy;

        public void Punch(Inventory characterInventory) => 
            characterInventory.Add(_itemFromSinglePunch);

        public void Occupy() => 
            _isBusy = true;
    }
}