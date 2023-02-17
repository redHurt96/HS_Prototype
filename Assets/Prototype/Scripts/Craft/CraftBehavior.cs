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
        
        private Inventory _inventory;

        private void Start() =>
            _inventory = GameObject.FindObjectOfType<Inventory>();

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