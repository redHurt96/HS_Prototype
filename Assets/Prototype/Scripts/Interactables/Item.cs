using System;
using UnityEngine;

namespace Prototype.Scripts.Interactables
{
    [Serializable]
    public struct Item
    {
        public bool IsFuel => ForgeClickCountFromSingleItem > 0;
        public int TotalForgeClicks => ForgeClickCountFromSingleItem * Count;
        
        public string Name;
        public int Count;
        
        [Header("For fuel")]
        public int ForgeClickCountFromSingleItem;

        public static Item CreateFrom(Item target, int targetCount) =>
            new()
            {
                Name = target.Name,
                Count = targetCount,
                ForgeClickCountFromSingleItem = target.ForgeClickCountFromSingleItem,
            };
    }
}