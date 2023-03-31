using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.Quests
{
    public class QuestPickableItem : QuestItem
    {
        [SerializeField] private ItemView _itemView;
        public ItemCell ItemCell;
    }
}