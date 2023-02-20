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
        public bool HasFuel => _fuelQueue.Count > 0;

        [SerializeField] private Inventory _inputInventory;
        [SerializeField] private Inventory _outputInventory;
        [SerializeField] private ForgeRecipe[] _recipes;

        private readonly Queue<CraftProcess> _itemsToCraft = new();
        private readonly Queue<Fuel> _fuelQueue = new();

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

            Fuel fuel = _fuelQueue.Peek();
            
            fuel.ForgeClickCount--;

            if (fuel.ForgeClickCount == 0)
                _fuelQueue.Dequeue();
        }

        internal void PutFuel(Item fuelItem, Inventory fromPlayerInventory)
        {
            if (!fuelItem.IsFuel)
                return;
            
            fromPlayerInventory.Remove(fuelItem);
            _fuelQueue.Enqueue(new()
            {
                Item = fuelItem,
                ForgeClickCount = fuelItem.Count * fuelItem.TotalForgeClicks,
            });
        }
    }

    internal class Fuel
    {
        internal Item Item;
        internal int ForgeClickCount;
    }
}