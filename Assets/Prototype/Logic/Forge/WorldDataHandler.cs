using System.Linq;
using Prototype.Logic.Craft;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;
using static System.IO.File;
using static System.IO.Path;
using static Prototype.Logic.Forge.WorldData;
using static UnityEngine.Application;
using static UnityEngine.GameObject;
using static UnityEngine.Input;
using static UnityEngine.JsonUtility;
using static UnityEngine.KeyCode;

namespace Prototype.Logic.Forge
{
    public class WorldDataHandler : MonoBehaviourSingleton<WorldDataHandler>
    {
        public static string Path => Combine(persistentDataPath, "Save.json");
        public bool HasData => Data.Islands is { Count: > 0 };

        public WorldData Data;

        [SerializeField] private Land _land;

        private void Awake()
        {
            if (Exists(Path))
                Data = FromJson<WorldData>(ReadAllText(Path));
        }

        private void Update()
        {
            if (GetKeyDown(F5))
                SaveData();
        }

        private void SaveData()
        {
            Data = new();
            Data.PlayerInventory = new();
            Data.PlayerInventory.Cells = FindGameObjectWithTag("Player")
                .GetComponent<Inventory>()
                .Cells
                .ToList();
            Data.Islands = new();

            foreach (Island island in _land.Islands)
            {
                IslandData islandData = new();
                islandData.StorageKey = island.StorageKey;
                islandData.UniqueKey = island.UniqueKey;
                islandData.Buildings = new();
                islandData.Position = island.transform.position;

                foreach (Building building in island.Buildings)
                {
                    BuildingData buildingData = new();
                    
                    buildingData.Name = building.Name;
                    buildingData.Position = building.transform.position;

                    if (building.TryGetComponent(out Inventory inventory))
                    {
                        buildingData.InventoryData = new()
                        {
                            Cells = inventory.Cells.ToList()
                        };
                    }

                    if (building.TryGetComponent(out ProductionBuildingBotPlace botPlace)
                        && !botPlace.IsEmpty)
                    {
                        buildingData.HasBot = true;
                    }
                    
                    islandData.Buildings.Add(buildingData);
                }
                
                Data.Islands.Add(islandData);
            }
            
            WriteAllText(Path, ToJson(Data));
        }
    }
}