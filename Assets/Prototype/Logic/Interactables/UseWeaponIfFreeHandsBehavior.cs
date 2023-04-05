using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.Interactables
{
    public class UseWeaponIfFreeHandsBehavior : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private CharacterEquipment _characterEquipment;

        private void Start() => 
            _inventory.Added += EquipIfFreeHands;

        private void OnDestroy() => 
            _inventory.Added += EquipIfFreeHands;

        private void EquipIfFreeHands(ItemCell cell)
        {
            Item item = ItemsStorage.Get(cell.ItemName);
            
            if (!_characterEquipment.HasSomeInHands && item.CanHoldInHands)
                _characterEquipment.Equip(item);
        }
    }
}