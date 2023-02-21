using System;
using System.Collections.Generic;
using System.Linq;
using Prototype.Scripts.Interactables;
using Prototype.Scripts.Items;
using UnityEngine;

namespace Prototype.Scripts.Craft
{
    public class CraftBehavior : MonoBehaviour
    {
        public event Action Updated;
        
        public List<Recipe> Recipes = new();
        
        private InventoryBehavior.Inventory _inventory;

        private void Start() =>
            _inventory = GameObject.FindObjectOfType<InventoryBehavior.Inventory>();

        public bool CanCraft(Recipe recipe) => 
            recipe
                .Ingredients
                .All(x => _inventory.Contains(x));

        public void Craft(Recipe recipe)
        {
            _inventory.Add(recipe.Item);

            foreach (Item ingredient in recipe.Ingredients) 
                _inventory.Remove(ingredient);
            
            Updated?.Invoke();
        }
    }
}