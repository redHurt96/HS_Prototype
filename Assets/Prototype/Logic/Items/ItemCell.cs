using System;
using Prototype.Logic.Attributes;
using static System.Guid;

namespace Prototype.Logic.Items
{
    [Serializable]
    public struct ItemCell
    {
        public bool IsEmpty => Count == 0;

        public string ItemName;
        [ReadOnly] public string Id;
        public int Count;
        public int ExpirationTime;

        private ItemCell(string id, string itemName)
        {
            Id = id;
            Count = 0;
            ExpirationTime = 0;
            ItemName = itemName;
        }
        
        public static ItemCell CreateWithTime(ItemCell origin, int withTime) =>
            new()
            {
                Id = origin.Id,
                ItemName = origin.ItemName,
                Count = origin.Count,
                ExpirationTime = withTime,
            };
        
        public static ItemCell CreateWithCount(ItemCell origin, int newCount) =>
            new()
            {
                Id = origin.Id,
                ItemName = origin.ItemName,
                Count = newCount,
                ExpirationTime = origin.ExpirationTime,
            };

        public ItemCell GenerateId() =>
            new()
            {
                Id = NewGuid().ToString(),
                ItemName = ItemName,
                Count = Count,
                ExpirationTime = ExpirationTime,
            };
    }
}