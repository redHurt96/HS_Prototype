using System;
using System.Collections.Generic;
using System.Linq;
using Prototype.Scripts.Items;
using UnityEngine;

namespace Prototype.Scripts.InventoryBehavior
{
    public class Inventory : MonoBehaviour
    {
        public event Action Updated;
        public IReadOnlyList<ItemCell> Items => _items;

        [SerializeField] private List<ItemCell> _items = new();

        public void Add(ItemCell cell)
        {
            if (_items.Exists(x => x.ItemName == cell.ItemName))
            {
                ItemCell targetCell = _items.Find(x => x.ItemName == cell.ItemName);
                int targetIndex = _items.IndexOf(targetCell);

                _items[targetIndex] = new()
                {
                    ItemName = targetCell.ItemName,
                    Count = targetCell.Count + cell.Count,
                };
            }
            else
            {
                _items.Add(cell);
            }
        }

        public bool Contains(ItemCell itemCell) => Contains(itemCell.ItemName, itemCell.Count);
        
        public bool Contains(string itemName, int count) => 
            _items
                .Exists(x => x.ItemName == itemName && x.Count >= count);

        public void Remove(ItemCell cell) => Remove(cell.ItemName, cell.Count);
        
        public void Remove(string itemName, int count)
        {
            if (!Contains(itemName, count))
                throw new($"Try to remove item which don't contains in inventory!");

            ItemCell target = _items.Find(x => x.ItemName == itemName);
            int index = _items.IndexOf(target);
            
            if (target.Count < count)
                throw new($"Try to remove item which count is bigger than in inventory!");

            _items[index] = new()
            {
                ItemName = itemName,
                Count = target.Count - count,
            };

            if (_items[index].Count == 0)
                _items.RemoveAt(index);
        }

        public void Add(List<ItemCell> recipeIngredients)
        {
            foreach (ItemCell item in recipeIngredients) 
                Add(item);
        }

        public void Remove(List<ItemCell> recipeIngredients)
        {
            foreach (ItemCell item in recipeIngredients) 
                Remove(item);
        }

        public bool Contains(List<ItemCell> recipeIngredients) => 
            recipeIngredients.All(Contains);

        public void InvokeUpdate() =>
            Updated?.Invoke();
    }
}