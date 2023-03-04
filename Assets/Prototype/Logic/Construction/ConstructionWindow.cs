﻿using System.Collections.Generic;
using Prototype.Logic.Craft;
using UnityEngine;
using static Prototype.Logic.Items.ConstructionDesignsStorage;

namespace Prototype.Logic.Construction
{
    public class ConstructionWindow : MonoBehaviour
    {
        [SerializeField] private ConstructionBehavior _constructionBehavior;
        [SerializeField] private RecipeUIView _recipeUIView;
        [SerializeField] private Transform _recipesAnchor;

        private readonly List<RecipeUIView> _recipesViews = new();

        private void Awake() =>
            _constructionBehavior.Updated += UpdateRecipesViews;

        private void OnDestroy() =>
            _constructionBehavior.Updated -= UpdateRecipesViews;

        private void OnEnable()
        {
            foreach (string designName in _constructionBehavior.Designs)
            {
                ConstructionDesign design = Get(designName);
                RecipeUIView recipeUIView = Instantiate(_recipeUIView, _recipesAnchor);

                recipeUIView.Setup(design, _constructionBehavior);
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