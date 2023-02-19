using System.Collections.Generic;
using Prototype.Scripts.Craft;
using Prototype.Scripts.InventoryBehavior;
using UnityEngine;

namespace Prototype.Scripts.Interactables
{
    internal class ForgeWindow : MonoBehaviour
    {
        [SerializeField] private ForgeRecipeUIView _recipeUIView;
        [SerializeField] private ForgeQueuedItemUIView _forgeQueuedItemUIView;

        [SerializeField] private InventoryWindow _craftedItemsInventoryWindow;
        [SerializeField] private InventoryWindow _playerInventoryWindow;
        
        [SerializeField] private Transform _recipesAnchor;
        [SerializeField] private Transform _queueAnchor;

        private Forge _forge;
        private Inventory _playerInventory;

        private readonly List<ForgeRecipeUIView> _recipesViews = new();
        private readonly List<ForgeQueuedItemUIView> _enqueuedItemsViews = new();

        internal void Show(Forge forge, Inventory playerInventory)
        {
            _playerInventory = playerInventory;
            _forge = forge;
            
            _playerInventoryWindow.SetInventory(playerInventory);
            _craftedItemsInventoryWindow.SetInventory(forge.OutputInventory);
            
            gameObject.SetActive(true);
        }

        internal void Hide() => 
            gameObject.SetActive(false);

        private void OnEnable()
        {
            foreach (ForgeRecipe recipe in _forge.Recipes)
            {
                ForgeRecipeUIView recipeUIView = Instantiate(_recipeUIView, _recipesAnchor);
                recipeUIView.Setup(recipe, _forge, _playerInventory);

                _recipesViews.Add(recipeUIView);
            }

            foreach (CraftProcess craftProcess in _forge.EnqueuedRecipes)
            {
                ForgeQueuedItemUIView itemView = Instantiate(_forgeQueuedItemUIView, _queueAnchor);
                itemView.Setup(craftProcess);
                
                _enqueuedItemsViews.Add(itemView);
            }
        }

        private void OnDisable()
        {
            foreach (ForgeRecipeUIView uiView in _recipesViews)
                Destroy(uiView.gameObject);
            _recipesViews.Clear();
            
            foreach (ForgeQueuedItemUIView uiView in _enqueuedItemsViews)
                Destroy(uiView.gameObject);
            _enqueuedItemsViews.Clear();
        }

        private void UpdateRecipesViews()
        {
            foreach (ForgeRecipeUIView view in _recipesViews)
                view.PerformUpdate();
            
            foreach (ForgeQueuedItemUIView uiView in _enqueuedItemsViews)
                uiView.PerformUpdate();
        }
    }
}