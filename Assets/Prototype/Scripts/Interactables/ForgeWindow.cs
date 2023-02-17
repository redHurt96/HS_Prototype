using System;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    internal class ForgeWindow : MonoBehaviour
    {
        [SerializeField] private RecipeUIView _recipeUIView;
        [SerializeField] private Transform _recipesAnchor;

        private CraftBehavior _craftBehavior;

        private readonly List<RecipeUIView> _recipesViews = new();

        internal void Show(Forge forge)
        {
            _craftBehavior = forge.CraftBehavior;
            gameObject.SetActive(true);
            _craftBehavior.Updated += UpdateRecipesViews;
        }

        internal void Hide()
        {
            gameObject.SetActive(false);

            if (_craftBehavior != null)
                _craftBehavior.Updated -= UpdateRecipesViews;
        }

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
                view.PerformUpdate();
        }
    }
}