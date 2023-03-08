using System;
using System.Linq;
using Prototype.Logic.Craft;
using Prototype.Logic.Forge;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;
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
                .All(x => _inventory.Contains(x))
            && design.CanBuildInBiome(_playerCurrentBiome.Value);

        public void Build(ConstructionDesign recipe)
        {
            if (!HasIslandBelowPoint(transform.position + transform.forward, out Island island))
                throw new($"Try to create building without ground below!");

            Building resource = GetBuildingPrefab(recipe.Name);
            
            Building instance = Instantiate(
                resource,
                transform.position + transform.forward,
                identity,
                island.transform);

            foreach (ItemCell ingredient in recipe.Materials)
                _inventory.Remove(ingredient);

            if (instance.Name is "storehouse" or "farm") 
                _village.RegisterStorehouse(instance.GetComponent<Inventory>());
            
            island.AddBuilding(instance);

            Updated?.Invoke();
        }
    }
}