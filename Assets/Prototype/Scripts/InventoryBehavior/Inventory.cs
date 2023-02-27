using System;
using System.Collections.Generic;
using System.Linq;
using Prototype.Scripts.Items;
using UnityEngine;
using static Prototype.Scripts.Items.ItemCell;
using static Prototype.Scripts.Items.ItemsStorage;

namespace Prototype.Scripts.InventoryBehavior
{
    public class Inventory : MonoBehaviour
    {
        public event Action Updated;
        public IReadOnlyList<ItemCell> Cells => _cells;

        [SerializeField] private List<ItemCell> _cells = new();

        public void Add(ItemCell cell)
        {
            Item item = Get(cell.ItemName);

            if (item.IsFood)
            {
                PutFood(item, cell.Count);
                return;
            }
            
            if (_cells.Exists(x => x.ItemName == cell.ItemName))
            {
                ItemCell targetCell = _cells.Find(x => x.ItemName == cell.ItemName);
                int targetIndex = _cells.IndexOf(targetCell);

                _cells[targetIndex] = new()
                {
                    ItemName = targetCell.ItemName,
                    Count = targetCell.Count + cell.Count,
                };
            }
            else
            {
                _cells.Add(cell);
            }
        }

        public bool Contains(ItemCell itemCell) => Contains(itemCell.ItemName, itemCell.Count);

        public bool Contains(string itemName, int count) => 
            _cells
                .Exists(x => x.ItemName == itemName && x.Count >= count);

        public void Remove(ItemCell cell) => Remove(cell.ItemName, cell.Count);

        public void Remove(string itemName, int count)
        {
            if (!Contains(itemName, count))
                throw new($"Try to remove item which don't contains in inventory!");

            ItemCell target = _cells.Find(x => x.ItemName == itemName);
            int index = _cells.IndexOf(target);
            
            if (target.Count < count)
                throw new($"Try to remove item which count is bigger than in inventory!");

            _cells[index] = new()
            {
                ItemName = itemName,
                Count = target.Count - count,
            };

            if (_cells[index].Count == 0)
                _cells.RemoveAt(index);
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

        private void PutFood(Item food, int count)
        {
            for (; count > 0; count--) 
                PutFood(food);
        }

        private void PutFood(Item food) =>
            _cells.Add(new()
            {
                ItemName = food.Name,
                Count = 1,
                ExpirationTime = food.ExpirationTimeSeconds,
            });

        public void RemoveAt(int position) => 
            _cells.RemoveAt(position);

        public void UpdateTime(int itemPosition, int time) => 
            _cells[itemPosition] = CreateWithTime(_cells[itemPosition], time);
    }
}