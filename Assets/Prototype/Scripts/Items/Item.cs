using System;
using UnityEngine;

namespace Prototype.Scripts.Items
{
    [Serializable]
    public struct Item
    {
        public bool IsFuel => ForgeClickCount > 0;
        public bool IsFood => NutritionalValue > 0f;

        public string Name;

        [Header("For fuel")]
        public int ForgeClickCount;

        [Header("For food")] 
        public float NutritionalValue;
        public float ExpirationTimeSeconds;
    }
}