using System;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    public class Forge : MonoBehaviour
    {
        public event Action Updated;

        internal IReadOnlyList<ForgeRecipe> Recipes => _recipes;

        [SerializeField] private CraftBehavior _craftBehavior;
        [SerializeField] private ForgeRecipe[] _recipes;

        private void Start() =>
            _craftBehavior.Updated += PerformUpdate;

        private void OnDestroy() =>
            _craftBehavior.Updated -= PerformUpdate;

        private void PerformUpdate() =>
            Updated?.Invoke();

        internal void Craft(ForgeRecipe recipe)
        {
            throw new NotImplementedException();
        }

        internal bool CanCraft(ForgeRecipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}