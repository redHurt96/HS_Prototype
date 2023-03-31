using System.Linq;
using UnityEngine;

namespace Prototype.Logic.Items
{
    [CreateAssetMenu(menuName = "Create ItemsStorage", fileName = "ItemsStorage", order = 0)]
    public class ItemsStorage : SingletonScriptableObject<ItemsStorage>
    {
        [SerializeField] private Item[] _items;

        public static Item Get(string itemName)
        {
            if (Instance._items.All(x => x.Name != itemName))
                throw new($"There is no item with name {itemName} in configs storage");
            
            return Instance
                ._items
                .First(x => x.Name == itemName);
        }
    }
}