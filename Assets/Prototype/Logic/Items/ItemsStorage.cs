using System.Linq;
using UnityEngine;

namespace Prototype.Logic.Items
{
    [CreateAssetMenu(menuName = "Create ItemsStorage", fileName = "ItemsStorage", order = 0)]
    public class ItemsStorage : ScriptableObject
    {
        public static ItemsStorage Instance { get; private set; }

        [SerializeField] private Item[] _items;

        public static Item Get(string itemName) =>
            Instance
                ._items
                .First(x => x.Name == itemName);

        public void InitSingleton() => 
            Instance = this;
    }
}