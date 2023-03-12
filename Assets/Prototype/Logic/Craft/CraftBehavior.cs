using System;
using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.Craft
{
    public class CraftBehavior : MonoBehaviour
    {
        public event Action Updated;
        
        public List<string> RecipesNames = new();
        
        [SerializeField] private Inventory _inventory;

        public bool CanCraft(Recipe recipe) => 
            recipe
                .Ingredients
                .All(x => _inventory.Contains(x));

        public void Craft(Recipe recipe)
        {
            _inventory.Add(recipe.Item);

            foreach (ItemCell ingredient in recipe.Ingredients) 
                _inventory.Remove(ingredient);
            
            Updated?.Invoke();
        }
    }
}