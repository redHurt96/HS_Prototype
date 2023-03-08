using System.Collections;
using System.Linq;
using Prototype.Logic.Craft;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using Unity.Mathematics;
using UnityEngine;
using static Prototype.Logic.Forge.WorldData;
using static Prototype.Logic.Interactables.ResourcesService;
using static UnityEngine.Resources;

namespace Prototype.Logic.Forge
{
    public class VillageRestorer : MonoBehaviour
    {
        [SerializeField] private LandExpander _landExpander;
        [SerializeField] private Village _village;
        [SerializeField] private Land _land;
        
        private IEnumerator Start()
        {
            if (!WorldDataHandler.Instance.HasData)
                yield break;

            yield return new WaitUntil(() => _landExpander.Loaded);
            
            foreach (IslandData islandData in WorldDataHandler.Instance.Data.Islands)
            {
                Island island = _land.Islands
                    .First(x => x.UniqueKey == islandData.UniqueKey);

                foreach (BuildingData buildingData in islandData.Buildings)
                {
                    Building instance = Instantiate(
                        GetBuildingPrefab(buildingData.Name),
                        buildingData.Position,
                        quaternion.identity,
                        island.transform);

                    _village.TryRegister(instance);
                    island.AddBuilding(instance);

                    if (buildingData.HasBot)
                    {
                        GameObject bot = Instantiate((GameObject)Load("Bot"), island.transform);
                        
                        instance
                            .GetComponent<ProductionBuildingBotPlace>()
                            .SetBot(bot);
                    }

                    if (buildingData.InventoryData != null)
                    {
                        instance
                            .GetComponent<Inventory>()
                            .Set(buildingData.InventoryData);
                    }
                }
            }
        }
    }
}