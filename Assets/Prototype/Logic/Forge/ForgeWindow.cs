using System.Collections.Generic;
using Prototype.Logic.Framework.UI;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;
using UnityEngine.UI;
using static Prototype.Logic.Items.ItemsStorage;

namespace Prototype.Logic.Forge
{
    internal class ForgeWindow : Window
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

        public override void Open(params object[] args)
        {
            _forge = (Forge)args[0];
            _playerInventory = (Inventory)args[1];

            _playerInventoryWindow.SetInventory(_playerInventory, PutFuel);
            _craftedItemsInventoryWindow.SetInventory(_forge.OutputInventory, AddToPlayer);
            
            gameObject.SetActive(true);
            
            base.Open(args);
        }

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

        private void PutFuel(ItemCell cell)
        {
            Item item = Get(cell.ItemName);
            
            if (item.IsFuel)
                _forge.PutFuel(cell, _playerInventory);
        }

        private void AddToPlayer(ItemCell cell)
        {
            _forge.OutputInventory.Remove(cell);
            _playerInventory.Add(cell);
            
            _forge.OutputInventory.InvokeUpdate();
            _playerInventory.InvokeUpdate();
        }
    }
}