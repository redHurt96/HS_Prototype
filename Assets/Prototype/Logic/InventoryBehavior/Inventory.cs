using System;
using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Items;
using UnityEngine;
using static Prototype.Logic.Forge.WorldData;
using static Prototype.Logic.Items.ItemCell;
using static Prototype.Logic.Items.ItemsStorage;

namespace Prototype.Logic.InventoryBehavior
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

                _cells[targetIndex] = CreateWithCount(_cells[targetIndex], targetCell.Count + cell.Count);
            }
            else
            {
                ItemCell cellToAdd = cell.GenerateId();
                _cells.Add(cellToAdd);
            }
        }

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

            ItemCell itemCell = _cells[index];
            itemCell.Count -= count;

            _cells[index] = itemCell;

            if (_cells[index].Count == 0)
                _cells.RemoveAt(index);
        }

        public void Remove(List<ItemCell> recipeIngredients)
        {
            foreach (ItemCell item in recipeIngredients) 
                Remove(item);
        }

        public bool Contains(ItemCell[] recipeIngredients) => Contains(recipeIngredients.ToList()); 
        public bool Contains(List<ItemCell> recipeIngredients) => 
            recipeIngredients.All(x => Contains(x.ItemName, x.Count));

        public void InvokeUpdate() =>
            Updated?.Invoke();

        private void PutFood(Item food, int count)
        {
            for (; count > 0; count--) 
                PutFood(food);
        }

        private void PutFood(Item food)
        {
            ItemCell itemCell = new()
            {
                ItemName = food.Name,
                Count = 1,
                ExpirationTime = food.ExpirationTimeSeconds,
            };
            
            _cells.Add(itemCell.GenerateId());
        }

        public void RemoveAt(int position) => 
            _cells.RemoveAt(position);

        public void UpdateTime(int itemPosition, int time) => 
            _cells[itemPosition] = CreateWithTime(_cells[itemPosition], time);

        public void Set(InventoryData inventoryData) => 
            _cells = inventoryData.Cells;

        public ItemCell GetCellById(string id) => 
            _cells.Find(x => x.Id == id);

        public bool ContainsCellWithId(string id) => 
            _cells.Exists(x => x.Id == id);
        
#if UNITY_EDITOR
        [ContextMenu(nameof(GenerateIds))]
        private void GenerateIds()
        {
            for (int i = 0; i < _cells.Count; i++) 
                _cells[i] = _cells[i].GenerateId();
        }
#endif
    }
}