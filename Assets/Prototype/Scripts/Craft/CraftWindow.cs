using System;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    public class CraftWindow : MonoBehaviour
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
            foreach (Recipe recipe in _craftBehavior.Recipes)
            {
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
            {
                view.PerformUpdate();
            }
        }
    }
}