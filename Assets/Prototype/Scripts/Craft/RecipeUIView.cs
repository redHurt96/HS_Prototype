using UnityEngine;
using UnityEngine.UI;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    internal class RecipeUIView : MonoBehaviour
    {
        [SerializeField] private ItemUIView _targetItemView;
        [SerializeField] private Transform _ingredientsAnchor;
        [SerializeField] private Button _craft;
        
        private CraftBehavior _craftBehavior;
        private Recipe _recipe;

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

        public void PerformUpdate() => 
            _craft.interactable = _craftBehavior.CanCraft(_recipe);
    }
}