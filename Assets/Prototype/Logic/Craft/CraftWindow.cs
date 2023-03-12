using System.Collections.Generic;
using Prototype.Logic.Framework.UI;
using UnityEngine;
using static Prototype.Logic.Items.CraftRecipes;

namespace Prototype.Logic.Craft
{
    public class CraftWindow : Window
    {
        [SerializeField] private CraftBehavior _craftBehavior;
        [SerializeField] private RecipeUIView _recipeUIView;
        [SerializeField] private Transform _recipesAnchor;

        private readonly List<RecipeUIView> _recipesViews = new();

        private void Awake() => 
            _craftBehavior.Updated += UpdateRecipesViews;

        private void OnDestroy() => 
            _craftBehavior.Updated -= UpdateRecipesViews;

        private void OnEnable()
        {
            foreach (string itemName in _craftBehavior.RecipesNames)
            {
                Recipe recipe = GetByTargetItem(itemName);
                RecipeUIView recipeUIView = Instantiate(_recipeUIView, _recipesAnchor);
                recipeUIView.Setup(recipe, _craftBehavior);
                
                _recipesViews.Add(recipeUIView);
            }
        }

        private void OnDisable()
        {
            foreach (RecipeUIView uiView in _recipesViews) 
                Destroy(uiView.gameObject);
            
            _recipesViews.Clear();
        }

        private void UpdateRecipesViews()
        {
            foreach (RecipeUIView view in _recipesViews) 
                view.PerformUpdate();
        }
    }
}