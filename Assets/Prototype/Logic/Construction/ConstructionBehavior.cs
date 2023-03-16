using System;
using System.Linq;
using Prototype.Logic.Craft;
using Prototype.Logic.Forge;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;
using static System.Guid;
using static Prototype.Logic.Interactables.ResourcesService;
using static Prototype.Logic.Items.IslandUtilities;
using static UnityEngine.Quaternion;

namespace Prototype.Logic.Construction
{
    public class ConstructionBehavior : MonoBehaviour
    {
        public event Action Updated;

        [SerializeField] private Village _village;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private CurrentBiomeIdentifier _playerCurrentBiome;

        public bool CanBuild(ConstructionDesign design) =>
            design
                .Materials
                .All(x => _inventory.Contains(x.ItemName, x.Count))
            && design.CanBuildInBiome(_playerCurrentBiome.Value);

        public void Build(ConstructionDesign recipe)
        {
            if (!HasIslandBelowPoint(transform.position + transform.forward * 3f, out Island island, out Vector3 topPoint))
                throw new($"Try to create building without ground below!");

            Building instance = Instantiate(
                GetBuildingPrefab(recipe.Name),
                topPoint,
                identity,
                island.transform);

            instance.UniqueKey = NewGuid().ToString();

            foreach (ItemCell ingredient in recipe.Materials)
                _inventory.Remove(ingredient);

            _village.Register(instance);

            Updated?.Invoke();
        }
    }
}