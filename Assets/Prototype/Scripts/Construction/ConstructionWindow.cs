using System.Collections.Generic;
using Prototype.Scripts.Craft;
using UnityEngine;

namespace Prototype.Scripts.Construction
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
            foreach (ConstructionDesign design in _constructionBehavior.Designs)
            {
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