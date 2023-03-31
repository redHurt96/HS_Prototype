using System;
using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Attributes;
using Prototype.Logic.Characters;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;
using static Prototype.Logic.Items.ItemsStorage;

namespace Prototype.Logic.Interactables
{
    public class FastAccessBehavior : MonoBehaviour
    {
        public event Action Updated;

        public IReadOnlyList<string> ItemsKeys => _items;
        public IReadOnlyList<ItemCell> Items => _items
            .Select(x => _inventory.GetCellById(x))
            .ToList();
        
        [SerializeField, ReadOnly] private string[] _items = new string[10];
        
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Hunger _hunger;
        [SerializeField] private Health _health;
        [SerializeField] private CharacterEquipment _equipment;

        private void Start() => 
            _inventory.Updated += UpdateItems;

        private void OnDestroy() => 
            _inventory.Updated -= UpdateItems;

        public bool HasItemAt(int index) => 
            !Items[index].IsEmpty;

        public void Put(string cellId)
        {
            if (_items.Any(x => x == cellId))
                return;
            
            for (int i = 0; i < _items.Length; i++)
            {
                if (string.IsNullOrEmpty(_items[i]))
                {
                    _items[i] = cellId;
                    
                    Updated?.Invoke();
                    
                    return;
                }
            }
        }

        public void Use(int index)
        {
            ItemCell cell = _inventory.GetCellById(_items[index]);
            Item item = Get(cell.ItemName);

            if (item.IsFood)
            {
                item.Feed(_hunger, _health, _inventory);
                Clear(index);
            }
            else if (item.HealthRestoreValue > 0f)
            {
                item.Heal(_health, _inventory);
            }
            else if (item.IsTool)
            {
                item.Equip(_equipment);
            }

            Updated?.Invoke();
        }

        public void Clear(int index)
        {
            _items[index] = null;
            Updated?.Invoke();
        }

        private void UpdateItems()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (string.IsNullOrEmpty(_items[i]))
                    continue;
                
                if (!_inventory.ContainsCellWithId(_items[i]))
                    Clear(i);
            }
        }

        public void Set(List<string> data) => 
            _items = data.ToArray();
    }
}