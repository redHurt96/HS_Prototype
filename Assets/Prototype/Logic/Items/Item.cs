using System;
using System.Linq;
using UnityEngine;

namespace Prototype.Logic.Items
{
    [Serializable]
    public struct Item
    {
        public bool IsFuel => ForgeClickCount > 0;
        public bool IsFood => NutritionalValue > 0f;
        public bool IsTool => MineItemNames.Any();

        public string Name;
        
        [Header("For fuel")]
        public int ForgeClickCount;

        [Header("For food")] 
        public float NutritionalValue;
        public int ExpirationTimeSeconds;

        [Header("For tools")] 
        public string[] MineItemNames;
        public int MineForce;

        public int GetMineForce(string mineItemName) =>
            MineItemNames.Any(x => x == mineItemName)
                ? MineForce
                : 0;
    }
}