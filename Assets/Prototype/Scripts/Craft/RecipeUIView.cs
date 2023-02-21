using Prototype.Scripts.Construction;
using Prototype.Scripts.Interactables;
using Prototype.Scripts.InventoryBehavior;
using Prototype.Scripts.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.Scripts.Craft
{
    internal class RecipeUIView : MonoBehaviour
    {
        [SerializeField] private ItemUIView _targetItemView;
        [SerializeField] private Transform _ingredientsAnchor;
        [SerializeField] private Button _craft;
        
        private CraftBehavior _craftBehavior;
        private Recipe _recipe;

        private ConstructionDesign _design;
        private ConstructionBehavior _constructionBehavior;

        public void Setup(Recipe recipe, CraftBehavior craftBehavior)
        {
            _recipe = recipe;
            _craftBehavior = craftBehavior;
            
            _targetItemView.Setup(recipe.Item);
            _craft.onClick.AddListener(() => craftBehavior.Craft(recipe));
            _craft.interactable = craftBehavior.CanCraft(recipe);

            foreach (Item ingredient in recipe.Ingredients)
            {
                ItemUIView itemView = Instantiate(_targetItemView, _ingredientsAnchor);
                itemView.Setup(ingredient);
            }
        }

        public void PerformUpdate()
        {
            if (_craftBehavior != null)
                _craft.interactable = _craftBehavior.CanCraft(_recipe);
            else if (_constructionBehavior != null)
                _craft.interactable = _constructionBehavior.CanBuild(_design);
        }

        internal void Setup(ConstructionDesign design, ConstructionBehavior constructionBehavior)
        {
            _design = design;
            _constructionBehavior = constructionBehavior;

            _targetItemView.Setup(design.Target);
            _craft.onClick.AddListener(() => constructionBehavior.Build(design));
            _craft.interactable = constructionBehavior.CanBuild(design);

            foreach (Item material in design.Materials)
            {
                ItemUIView itemView = Instantiate(_targetItemView, _ingredientsAnchor);
                itemView.Setup(material);
            }
        }
    }
}