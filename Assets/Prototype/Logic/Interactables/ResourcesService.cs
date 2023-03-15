using Prototype.Logic.Craft;
using Prototype.Logic.Items;
using UnityEngine;
using static UnityEngine.Resources;

namespace Prototype.Logic.Interactables
{
    public static class ResourcesService
    {
        public static Sprite GetItemIcon(string itemName) => 
            Load<Sprite>($"Items/Icons/{itemName.ToLower()}");

        internal static Sprite GetBuildingIcon(Building target) =>
            Load<Sprite>($"Buildings/Icons/{target.Name.ToLower()}");
        
        internal static ItemView GetItemPrefab(string itemName) =>
            Load<ItemView>($"Items/Prefabs/{itemName}");
        
        internal static GameObject GetEnvironmentItemPrefab(string itemName) =>
            Load<GameObject>($"Environment/{itemName}");
        
        internal static Building GetBuildingPrefab(string itemName) =>
            Load<Building>($"Buildings/Prefabs/{itemName}");
        
        internal static GameObject GetMineFieldPrefab(string itemName) =>
            Load<GameObject>($"MineFields/{itemName}");
    }
}