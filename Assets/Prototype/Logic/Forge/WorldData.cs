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
        public InventoryData PlayerInventory;

        [Serializable]
        public class IslandData
        {
            public string StorageKey;
            public string UniqueKey;
            public List<BuildingData> Buildings;
            public Vector3 Position;
        }

        [Serializable]
        public class BuildingData
        {
            public string Name;
            public Vector3 Position;
            public bool HasBot = false;
            public InventoryData InventoryData;
        }

        [Serializable]
        public class InventoryData
        {
            public List<ItemCell> Cells;
        }
    }
}