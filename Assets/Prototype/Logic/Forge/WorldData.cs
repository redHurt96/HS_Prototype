using System;
using System.Collections.Generic;
using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    [Serializable]
    public class WorldData
    {
        public List<IslandData> Islands;
        public List<BotData> Bots;
        public InventoryData PlayerInventory;
        public List<BuildingData> Buildings;

        [Serializable]
        public class IslandData
        {
            public string StorageKey;
            public string UniqueKey;
            public Vector3 Position;
            public List<MineFieldData> MineFields;
        }

        [Serializable]
        public class MineFieldData
        {
            public int PointIndex;
            public string ItemName;
        }
        
        [Serializable]
        public class BuildingData
        {
            public string Name;
            public string UniqueKey;
            public Vector3 Position;
            public InventoryData InventoryData;
        }

        [Serializable]
        public class InventoryData
        {
            public List<ItemCell> Cells;
        }
        
        [Serializable]
        public class BotData
        {
            public string Name;
            public string BuildingKey;
        }
    }
}