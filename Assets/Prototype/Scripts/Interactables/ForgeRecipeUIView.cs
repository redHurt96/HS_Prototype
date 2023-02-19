using Prototype.Scripts.Craft;
using Prototype.Scripts.InventoryBehavior;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.Scripts.Interactables
{
    internal class ForgeRecipeUIView : MonoBehaviour
    {
        [SerializeField] private ItemUIView _targetItemView;
        [SerializeField] private TextMeshProUGUI _forgeTime;
        [SerializeField] private Transform _ingredientsAnchor;
        [SerializeField] private Button _craft;

        private ForgeRecipe _recipe;
        private Forge _forge;
        private InventoryBehavior.Inventory _playerInventory;

        internal void Setup(ForgeRecipe recipe, Forge forge, InventoryBehavior.Inventory playerInventory)
        {
            _playerInventory = playerInventory;
            _recipe = recipe;
            _forge = forge;

            _targetItemView.Setup(recipe.Recipe.Item);
            _craft.onClick.AddListener(() => _forge.EnqueueRecipe(recipe, playerInventory));
            _craft.interactable = _forge.CanCraft(recipe, playerInventory);

            foreach (Item ingredient in recipe.Recipe.Ingredients)
            {
                ItemUIView itemView = Instantiate(_targetItemView, _ingredientsAnchor);
                itemView.Setup(ingredient);
            }
        }

        public void PerformUpdate()
        {
            if (_forge != null)
                _craft.interactable = _forge.CanCraft(_recipe, _playerInventory);
        }
    }
}