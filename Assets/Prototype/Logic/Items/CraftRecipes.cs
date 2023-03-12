using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Craft;
using UnityEngine;

namespace Prototype.Logic.Items
{
    [CreateAssetMenu(menuName = "Create CraftRecipes", fileName = "CraftRecipes", order = 0)]
    public class CraftRecipes : SingletonScriptableObject<CraftRecipes>
    {
        [SerializeField] private List<Recipe> _recipes = new();

        public static Recipe GetByTargetItem(string itemName) =>
            Instance
                ._recipes
                .First(x => x.Item.ItemName == itemName);
    }
}