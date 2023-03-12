using UnityEngine;
using static Prototype.Logic.Items.ItemsStorage;

namespace Prototype.Logic.Items
{
    public class ItemView : MonoBehaviour
    {
        public ItemCell ItemCell;

        private void Start()
        {
            Item item = GetItem();

            if (!item.IsFood)
                return;

            ItemCell.ExpirationTime = item.ExpirationTimeSeconds;
        }

        public int GetForce(MineItemView mineItemView) => 
            GetItem()
                .GetMineForce(mineItemView.Name);

        private Item GetItem() => 
            Get(ItemCell.ItemName);
    }
}
