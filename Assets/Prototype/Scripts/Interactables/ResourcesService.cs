using Prototype.Scripts.Craft;
using Prototype.Scripts.Items;
using UnityEngine;
using static UnityEngine.Resources;

namespace Prototype.Scripts.Interactables
{
    public static class ResourcesService
    {
        public static Sprite GetItemIcon(string itemName) => 
            Load<Sprite>($"Icons/{itemName.ToLower()}");

        internal static Sprite GetBuildingIcon(Building target) =>
            Load<Sprite>($"Icons/{target.Name.ToLower()}");
    }
}