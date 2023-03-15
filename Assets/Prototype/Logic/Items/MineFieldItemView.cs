using Prototype.Logic.InventoryBehavior;
using UnityEngine;

namespace Prototype.Logic.Items
{
    public class MineFieldItemView : MonoBehaviour
    {
        public string Name => _itemFromSinglePunch.ItemName;
        
        [SerializeField] private ItemCell _itemFromSinglePunch;

        public void Punch(Inventory characterInventory) => 
            characterInventory.Add(_itemFromSinglePunch);
    }
}