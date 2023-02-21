using System;
using System.Collections.Generic;
using System.Linq;
using Prototype.Scripts.Interactables;
using Prototype.Scripts.Items;
using UnityEngine;
using static Prototype.Scripts.Items.Item;

namespace Prototype.Scripts.InventoryBehavior
{
    public class Inventory : MonoBehaviour
    {
        public event Action Updated;
        public IReadOnlyList<Item> Items => _items;

        [SerializeField] private List<Item> _items = new();

        public void Add(Item item)
        {
            if (_items.Exists(x => x.Name == item.Name))
            {
                Item targetItem = _items.Find(x => x.Name == item.Name);
                int targetIndex = _items.IndexOf(targetItem);

                _items[targetIndex] = CreateFrom(targetItem, targetItem.Count + item.Count);
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
            int index = _items.IndexOf(target);
            
            if (target.Count < item.Count)
                throw new($"Try to remove item which count is bigger than in inventory!");

            _items[index] = CreateFrom(target, target.Count - item.Count);

            if (_items[index].Count == 0)
                _items.RemoveAt(index);
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

        public void InvokeUpdate() =>
            Updated?.Invoke();
    }
}