using System;
using System.Collections.Generic;
using Prototype.Scripts.Craft;
using UnityEngine;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    internal class ForgeWindow : MonoBehaviour
    {
        [SerializeField] private ForgeRecipeUIView _recipeUIView;
        [SerializeField] private Transform _recipesAnchor;
        [SerializeField] private Transform _queueAnchor;

        private Forge _forge;

        private readonly List<ForgeRecipeUIView> _recipesViews = new();

        internal void Show(Forge forge)
        {
            _forge = forge;
            gameObject.SetActive(true);
            _forge.Updated += UpdateRecipesViews;
        }

        internal void Hide()
        {
            gameObject.SetActive(false);

            if (_forge != null)
                _forge.Updated -= UpdateRecipesViews;
        }

        private void OnEnable()
        {
            foreach (ForgeRecipe recipe in _forge.Recipes)
            {
                ForgeRecipeUIView recipeUIView = Instantiate(_recipeUIView, _recipesAnchor);
                recipeUIView.Setup(recipe, _forge);

                _recipesViews.Add(recipeUIView);
            }
        }

        private void OnDisable()
        {
            foreach (ForgeRecipeUIView uiView in _recipesViews)
                Destroy(uiView.gameObject);

            _recipesViews.Clear();
        }

        private void UpdateRecipesViews()
        {
            foreach (ForgeRecipeUIView view in _recipesViews)
                view.PerformUpdate();
        }
    }
}