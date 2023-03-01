using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.Logic.Forge
{
    internal class ForgeRecipeUIView : MonoBehaviour
    {
        [SerializeField] private ItemUIView _targetItemView;
        [SerializeField] private TextMeshProUGUI _clicksCount;
        [SerializeField] private Transform _ingredientsAnchor;
        [SerializeField] private Button _craft;

        private Forge _forge;

        internal void Setup(ForgeRecipe recipe, Forge forge, Inventory playerInventory)
        {
            _forge = forge;

            _targetItemView.Setup(recipe.Recipe.Item);
            _craft.onClick.AddListener(() => _forge.EnqueueRecipe(recipe, playerInventory));
            _craft.interactable = _forge.CanCraft(recipe, playerInventory);
            _clicksCount.text = recipe.ClickCount.ToString();

            foreach (ItemCell ingredient in recipe.Recipe.Ingredients)
            {
                ItemUIView itemView = Instantiate(_targetItemView, _ingredientsAnchor);
                itemView.Setup(ingredient);
            }
        }
    }
}