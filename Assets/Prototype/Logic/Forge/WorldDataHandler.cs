using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Attributes;
using Prototype.Logic.Craft;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;
using static System.IO.File;
using static System.IO.Path;
using static System.String;
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

        [ReadOnly] public WorldData Data;

        [SerializeField] private Land _land;
        [SerializeField] private Village _village;

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

            SaveInventory();
            SaveIslands();
            SaveBuildings();
            SaveBots();
            
            WriteAllText(Path, ToJson(Data));
        }

        private void SaveInventory()
        {
            Data.PlayerInventory = new();
            Data.PlayerInventory.Cells = FindGameObjectWithTag("Player")
                .GetComponent<Inventory>()
                .Cells
                .ToList();
        }

        private void SaveBots()
        {
            Data.Bots = new();

            foreach (Bot bot in _village.Bots)
            {
                BotData botData = new();
                botData.Name = bot.Name;

                if (!IsNullOrEmpty(bot.BuildingKey))
                    botData.BuildingKey = bot.BuildingKey;

                Data.Bots.Add(botData);
            }
        }

        private void SaveBuildings()
        {
            Data.Buildings = new();

            foreach (Building building in _village.Buildings)
            {
                BuildingData buildingData = new();

                buildingData.Name = building.Name;
                buildingData.UniqueKey = building.UniqueKey;
                buildingData.Position = building.transform.position;

                if (building.TryGetComponent(out Inventory inventory))
                {
                    buildingData.InventoryData = new()
                    {
                        Cells = inventory.Cells.ToList()
                    };
                }
                
                Data.Buildings.Add(buildingData);
            }
        }

        private void SaveIslands()
        {
            Data.Islands = new();

            foreach (Island island in _land.Islands)
            {
                IslandData islandData = new();
                
                islandData.StorageKey = island.StorageKey;
                islandData.UniqueKey = island.UniqueKey;
                islandData.Position = island.transform.position;
                islandData.Rotation = island.transform.localRotation.eulerAngles;
                
                islandData.MineFields = new();
                
                foreach (KeyValuePair<int,string> mineField in island.MineFields)
                {
                    islandData.MineFields.Add(new()
                    {
                        PointIndex = mineField.Key,
                        ItemName = mineField.Value,
                    });
                }

                Data.Islands.Add(islandData);
            }
        }
    }
}