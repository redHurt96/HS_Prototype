using Prototype.Logic.Construction;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;
using UnityEngine.UI;
using static Prototype.Logic.Interactables.ResourcesService;

namespace Prototype.Logic.Craft
{
    internal class RecipeUIView : MonoBehaviour
    {
        [SerializeField] private ItemUIView _targetItemView;
        [SerializeField] private Transform _ingredientsAnchor;
        [SerializeField] private Button _craft;
        
        private CraftBehavior _craftBehavior;
        private Recipe _recipe;
        private ConstructionDesign _design;
        private BuildBehavior _buildBehavior;

        public void Setup(Recipe recipe, CraftBehavior craftBehavior)
        {
            _recipe = recipe;
            _craftBehavior = craftBehavior;
            
            _targetItemView.Setup(recipe.Item);
            _craft.onClick.AddListener(() => craftBehavior.Craft(recipe));
            _craft.interactable = craftBehavior.CanCraft(recipe);

            foreach (ItemCell ingredient in recipe.Ingredients)
            {
                ItemUIView itemView = Instantiate(_targetItemView, _ingredientsAnchor);
                itemView.Setup(ingredient);
            }
        }

        public void PerformUpdate()
        {
            if (_craftBehavior != null)
                _craft.interactable = _craftBehavior.CanCraft(_recipe);
            else if (_buildBehavior != null)
                _craft.interactable = _buildBehavior.CanBuild(_design);
        }

        internal void Setup(ConstructionDesign design, BuildBehavior buildBehavior)
        {
            _design = design;
            _buildBehavior = buildBehavior;
            Building building = GetBuildingPrefab(design.Name);

            _targetItemView.Setup(building);
            _craft.onClick.AddListener(() => buildBehavior.Build(design));
            _craft.interactable = buildBehavior.CanBuild(design);

            foreach (ItemCell material in design.Materials)
            {
                ItemUIView itemView = Instantiate(_targetItemView, _ingredientsAnchor);
                itemView.Setup(material);
            }
        }
    }
}