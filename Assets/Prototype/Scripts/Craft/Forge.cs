using System.Collections.Generic;
using Prototype.Scripts.Interactables;
using Prototype.Scripts.InventoryBehavior;
using UnityEngine;

namespace Prototype.Scripts.Craft
{
    public class Forge : MonoBehaviour
    {
        public IReadOnlyList<ForgeRecipe> Recipes => _recipes;
        public IReadOnlyCollection<CraftProcess> EnqueuedRecipes => _itemsToCraft;
        public IReadOnlyList<Item> CraftedItems => _outputInventory.Items;
        public bool HasItemsToCraft => _itemsToCraft.Count > 0;
        public Inventory OutputInventory => _outputInventory;

        public bool HasFuel;

        [SerializeField] private Inventory _inputInventory;
        [SerializeField] private Inventory _outputInventory;
        [SerializeField] private ForgeRecipe[] _recipes;

        private readonly Queue<CraftProcess> _itemsToCraft;

        internal void EnqueueRecipe(ForgeRecipe recipe, Inventory fromPlayerInventory)
        {
            fromPlayerInventory.Remove(recipe.Recipe.Ingredients);
            _inputInventory.Add(recipe.Recipe.Ingredients);

            _itemsToCraft.Enqueue(new(recipe.Recipe.Item, recipe.ClickCount));
        }

        internal bool CanCraft(ForgeRecipe recipe, Inventory fromPlayerInventory) => 
            fromPlayerInventory.Contains(recipe.Recipe.Ingredients);

        internal void PerformCraft()
        {
            if (!HasItemsToCraft)
                return;
            
            if (!HasFuel)
                return;

            CraftProcess current = _itemsToCraft.Peek();
            
            current.ClickCount--;

            if (current.ClickCount is 0)
            {
                _outputInventory.Add(current.Target);
                _itemsToCraft.Dequeue();
            }
        }
    }
}