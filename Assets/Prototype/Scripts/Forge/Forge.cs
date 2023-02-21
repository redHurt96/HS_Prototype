using System;
using System.Collections.Generic;
using Prototype.Scripts.InventoryBehavior;
using Prototype.Scripts.Items;
using UnityEngine;

namespace Prototype.Scripts.Forge
{
    public class Forge : MonoBehaviour
    {
        public event Action FuelUpdated;
        public event Action ItemsQueueUpdated;
        
        public IReadOnlyList<ForgeRecipe> Recipes => _recipes;
        public IReadOnlyCollection<ForgeCraftProcess> EnqueuedRecipes => _itemsToCraft;
        public IReadOnlyCollection<Fuel> FuelQueue => _fuelQueue;
        public bool HasItemsToCraft => _itemsToCraft.Count > 0;
        public Inventory OutputInventory => _outputInventory;
        public bool HasFuel => _fuelQueue.Count > 0;

        [SerializeField] private Inventory _outputInventory;
        [SerializeField] private ForgeRecipe[] _recipes;

        private readonly Queue<ForgeCraftProcess> _itemsToCraft = new();
        private readonly Queue<Fuel> _fuelQueue = new();

        internal void EnqueueRecipe(ForgeRecipe recipe, Inventory fromPlayerInventory)
        {
            fromPlayerInventory.Remove(recipe.Recipe.Ingredients);
            _itemsToCraft.Enqueue(new(recipe.Recipe.Item, recipe.ClickCount));

            fromPlayerInventory.InvokeUpdate();
            ItemsQueueUpdated?.Invoke();
        }

        internal bool CanCraft(ForgeRecipe recipe, Inventory fromPlayerInventory) => 
            fromPlayerInventory.Contains(recipe.Recipe.Ingredients);

        internal void PerformCraft()
        {
            if (!HasItemsToCraft)
                return;
            
            if (!HasFuel)
                return;

            ForgeCraftProcess current = _itemsToCraft.Peek();
            
            current.ClickCount--;

            if (current.ClickCount is 0)
            {
                _outputInventory.Add(current.Target);
                _itemsToCraft.Dequeue();
                
                _outputInventory.InvokeUpdate();
            }

            Fuel fuel = _fuelQueue.Peek();
            
            fuel.ForgeClickCount--;

            if (fuel.ForgeClickCount == 0)
                _fuelQueue.Dequeue();
            
            ItemsQueueUpdated?.Invoke();
            FuelUpdated?.Invoke();
        }

        internal void PutFuel(Item fuelItem, Inventory fromPlayerInventory)
        {
            if (!fuelItem.IsFuel)
                return;
            
            fromPlayerInventory.Remove(fuelItem);
            _fuelQueue.Enqueue(new()
            {
                Item = fuelItem,
                ForgeClickCount = fuelItem.TotalForgeClicks,
            });
            
            FuelUpdated?.Invoke();
            fromPlayerInventory.InvokeUpdate();
        }
    }

    public class Fuel
    {
        internal Item Item;
        internal int ForgeClickCount;
    }
}