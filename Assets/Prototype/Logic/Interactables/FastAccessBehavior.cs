using System;
using System.Collections.Generic;
using Prototype.Logic.Attributes;
using Prototype.Logic.Characters;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;
using static Prototype.Logic.Items.ItemCell;
using static Prototype.Logic.Items.ItemsStorage;

namespace Prototype.Logic.Interactables
{
    public class FastAccessBehavior : MonoBehaviour
    {
        public event Action Updated;
        public IReadOnlyList<ItemCell> Items => _items;
        
        [SerializeField, ReadOnly] private ItemCell[] _items = new ItemCell[10];
        
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Hunger _hunger;
        [SerializeField] private CharacterEquipment _equipment;

        public bool HasItemAt(int index) => 
            !Items[index].IsEmpty;

        public void Put(ItemCell item)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].IsEmpty)
                {
                    _items[i] = item;
                    
                    Updated?.Invoke();
                    
                    return;
                }
            }
        }

        public void Use(int index)
        {
            Item item = Get(_items[index].ItemName);

            if (item.IsFood)
            {
                item.Feed(_hunger, _inventory);
                Clear(index);
            }
            else if (item.IsTool)
            {
                item.Equip(_equipment);
            }

            Updated?.Invoke();
        }

        public void Clear(int index)
        {
            _items[index] = default;
            Updated?.Invoke();
        }

        public void UpdateTime(int i, int expirationTime) => 
            _items[i] = CreateWithTime(_items[i], expirationTime);
    }
}