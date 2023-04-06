using System;
using Prototype.Logic.Characters;
using Prototype.Logic.Interactables;
using Prototype.Logic.Items;

namespace Prototype.Logic.InventoryBehavior
{
    public static class ItemExtensions
    {
        public static event Action<string> Used;
        
        public static void Feed(this Item item, Hunger hunger, Health health, Mind mind, Inventory inventory)
        {
            hunger.Feed(item.NutritionalValue);
            
            if (item.HealthRestoreValue > 0f)
                health.Add(item.HealthRestoreValue);
            
            if (item.MindRestoreValue > 0f)
                mind.Add(item.MindRestoreValue);
            
            inventory.Remove(item.Name, 1);
            inventory.InvokeUpdate();
            
            Used?.Invoke(item.Name);
        }
        
        public static void Equip(this Item item, CharacterEquipment equipment)
        {
            equipment.Equip(item);

            Used?.Invoke(item.Name);
        }
    }
}