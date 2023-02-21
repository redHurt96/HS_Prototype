using System;
using UnityEngine;

namespace Prototype.Scripts.Items
{
    [Serializable]
    public struct Item
    {
        public bool IsFuel => ForgeClickCountFromSingleItem > 0;
        public int TotalForgeClicks => ForgeClickCountFromSingleItem * Count;
        public bool IsFood => NutritionalValue > 0f;

        public string Name;
        public int Count;

        [Header("For fuel")]
        public int ForgeClickCountFromSingleItem;

        [Header("For food")] 
        public float NutritionalValue;
        public float ExpirationTime;

        public static Item CreateFrom(Item target, int targetCount) =>
            new()
            {
                Name = target.Name,
                Count = targetCount,
                ForgeClickCountFromSingleItem = target.ForgeClickCountFromSingleItem,
            };
    }
}