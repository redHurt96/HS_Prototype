using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    public class CraftBehavior : MonoBehaviour
    {
        public event Action Updated;
        
        public List<Recipe> Recipes = new();
        
        [SerializeField] private Inventory _inventory;

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