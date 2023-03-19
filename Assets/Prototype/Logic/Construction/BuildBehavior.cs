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
    public class BuildBehavior : MonoBehaviour
    {
        public event Action Updated;

        [SerializeField] private Village _village;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private CurrentIslandIdentifier _playerCurrentIsland;
        [SerializeField] private MineFieldDetector _mineFieldDetector;

        public bool CanBuild(ConstructionDesign design) =>
            design
                .Materials
                .All(x => _inventory.Contains(x.ItemName, x.Count))
            && design.CanBuildInBiome(_playerCurrentIsland.Value)
            && (!design.BuildOnlyOnField || _mineFieldDetector.HasProperMineFieldNearby(design.MineFieldName));

        public void Build(ConstructionDesign recipe)
        {
            Vector3 position;
            Island island;
            
            if (recipe.BuildOnlyOnField)
            {
                MineFieldItemView mineField = _mineFieldDetector.GetProperMineFieldNearby(recipe.MineFieldName);

                position = mineField.transform.position;
                island = _playerCurrentIsland.Island;

                mineField.Occupy();
            }
            else
            {
                if (!HasIslandBelowPoint(transform.position + transform.forward * 3f, out island, out position))
                    throw new($"Try to create building without ground below!");
            }
                          
            Building instance = Instantiate(
                GetBuildingPrefab(recipe.Name),
                position,
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