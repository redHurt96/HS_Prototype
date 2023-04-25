using System;
using System.Linq;
using UnityEngine;

namespace Prototype.Logic.Items
{
    [Serializable]
    public struct Item
    {
        public bool IsEmpty => string.IsNullOrEmpty(Name);
        public bool IsFuel => ForgeClickCount > 0;
        public bool IsFood => NutritionalValue > 0f;

        public string Name;
        
        public bool CanHoldInHands;
        public bool IsMelee;
        
        [Header("For fuel")]
        public int ForgeClickCount;

        [Header("For food or aid kits")] 
        public float HealthRestoreValue;
        public float MindRestoreValue;
        public float NutritionalValue;
        public int ExpirationTimeSeconds;

        [Header("For tools")] 
        //public bool IsTool;
        public string[] MineItemNames;
        public int MineForce;

        public int GetMineForce(string mineItemName) =>
            MineItemNames.Any(x => x == mineItemName)
                ? MineForce
                : 0;
    }
}