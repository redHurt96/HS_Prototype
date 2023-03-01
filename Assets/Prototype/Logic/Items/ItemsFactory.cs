using UnityEngine;
using static UnityEngine.GameObject;
using static UnityEngine.Object;
using static UnityEngine.Resources;

namespace Prototype.Logic.Items
{
    public static class ItemsFactory
    {
        private static Transform _parent;

        public static ItemView Create(string itemName, Vector3 position)
        {
            _parent ??= FindGameObjectWithTag("ItemsParent").transform;
        
            ItemView resource = Load<ItemView>($"Prefabs/{itemName}");
            return Instantiate(resource, position, Quaternion.identity, _parent);
        }
    }
}