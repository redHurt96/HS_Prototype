using Prototype.Logic.Characters;
using Prototype.Logic.Interactables;
using Prototype.Logic.Items;

namespace Prototype.Logic.InventoryBehavior
{
    public static class ItemExtensions
    {
        public static void Feed(this Item item, Hunger hunger, Inventory inventory)
        {
            hunger.Feed(item.NutritionalValue);
            inventory.Remove(item.Name, 1);
            inventory.InvokeUpdate();
        }
        
        public static void Equip(this Item item, CharacterEquipment equipment) => 
            equipment.Equip(item);
    }
}