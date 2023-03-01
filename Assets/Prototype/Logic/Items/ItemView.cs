using UnityEngine;
using static Prototype.Logic.Items.ItemsStorage;

namespace Prototype.Logic.Items
{
    public class ItemView : MonoBehaviour
    {
        public ItemCell ItemCell;

        private void Start()
        {
            Item item = Get(ItemCell.ItemName);

            if (!item.IsFood)
                return;

            ItemCell.ExpirationTime = item.ExpirationTimeSeconds;
        }
    }
}
