using System;

namespace Prototype.Scripts.Items
{
    [Serializable]
    public struct ItemCell
    {
        public string ItemName;
        public int Count;
        public int ExpirationTime;

        public static ItemCell CreateWithTime(ItemCell origin, int withTime) =>
            new()
            {
                ItemName = origin.ItemName,
                Count = origin.Count,
                ExpirationTime = withTime,
            };
    }
}