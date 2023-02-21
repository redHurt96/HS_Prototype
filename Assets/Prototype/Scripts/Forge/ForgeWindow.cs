using System.Collections.Generic;
using Prototype.Scripts.InventoryBehavior;
using Prototype.Scripts.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.Scripts.Forge
{
    internal class ForgeWindow : MonoBehaviour
    {
        [SerializeField] private ForgeRecipeUIView _recipeUIView;
        [SerializeField] private TradeInventoryWindow _craftedItemsInventoryWindow;
        [SerializeField] private TradeInventoryWindow _playerInventoryWindow;
        [SerializeField] private FuelsPanel _fuelsPanel;
        [SerializeField] private ForgeQueuedItemsPanel _queuedItemsPanel;
        [SerializeField] private Transform _recipesAnchor;
        [SerializeField] private Button _craft;

        private Forge _forge;
        private Inventory _playerInventory;
        
        private readonly List<ForgeRecipeUIView> _recipesViews = new();

        internal void Show(Forge forge, Inventory playerInventory)
        {
            _playerInventory = playerInventory;
            _forge = forge;
            
            _playerInventoryWindow.SetInventory(playerInventory, PutFuel);
            _craftedItemsInventoryWindow.SetInventory(forge.OutputInventory, AddToPlayer);
            
            gameObject.SetActive(true);
        }

        internal void Hide() => 
            gameObject.SetActive(false);

        private void OnEnable()
        {
            _fuelsPanel.Setup(_forge);
            _queuedItemsPanel.Setup(_forge);
            
            _craft.onClick.AddListener(_forge.PerformCraft);
            
            foreach (ForgeRecipe recipe in _forge.Recipes)
            {
                ForgeRecipeUIView recipeUIView = Instantiate(_recipeUIView, _recipesAnchor);
                recipeUIView.Setup(recipe, _forge, _playerInventory);

                _recipesViews.Add(recipeUIView);
            }
        }

        private void OnDisable()
        {
            _fuelsPanel.Clear();
            _queuedItemsPanel.Clear();
            
            _craft.onClick.RemoveListener(_forge.PerformCraft);
            
            foreach (ForgeRecipeUIView uiView in _recipesViews)
                Destroy(uiView.gameObject);
            _recipesViews.Clear();
        }

        private void PutFuel(Item item)
        {
            if (!item.IsFuel)
                return;
            
            _forge.PutFuel(item, _playerInventory);
        }

        private void AddToPlayer(Item item)
        {
            _forge.OutputInventory.Remove(item);
            _playerInventory.Add(item);
            
            _forge.OutputInventory.InvokeUpdate();
            _playerInventory.InvokeUpdate();
        }
    }
}