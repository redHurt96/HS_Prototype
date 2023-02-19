using System.Collections.Generic;
using System.Linq;
using Prototype.Scripts.Interactables;
using UnityEngine;

namespace Prototype.Scripts.InventoryBehavior
{
    public class Inventory : MonoBehaviour
    {
        public IReadOnlyList<Item> Items => _items;
        
        [SerializeField] private List<Item> _items = new();

        public void Add(Item item)
        {
            if (_items.Exists(x => x.Name == item.Name))
            {
                Item targetItem = _items.Find(x => x.Name == item.Name);
                int targetIndex = _items.IndexOf(targetItem);

                _items[targetIndex] = new Item()
                {
                    Name = item.Name,
                    Count = targetItem.Count + item.Count,
                };
            }
            else
            {
                _items.Add(item);
            }
        }

        public bool Contains(Item item) => 
            _items
                .Exists(x => x.Name == item.Name && x.Count >= item.Count);

        public void Remove(Item item)
        {
            if (!Contains(item))
                throw new($"Try to remove item which don't contains in inventory!");

            Item target = _items.Find(x => x.Name == item.Name);
            
            if (target.Count < item.Count)
                throw new($"Try to remove item which count is bigger than in inventory!");

            target.Count -= item.Count;

            if (target.Count == 0)
                _items.Remove(target);
        }

        public void Add(List<Item> recipeIngredients)
        {
            foreach (Item item in recipeIngredients) 
                Add(item);
        }

        public void Remove(List<Item> recipeIngredients)
        {
            foreach (Item item in recipeIngredients) 
                Remove(item);
        }

        public bool Contains(List<Item> recipeIngredients) => 
            recipeIngredients.All(Contains);
    }
}