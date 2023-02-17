using System;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.Resources;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    public static class ResourcesService
    {
        public static Sprite GetItemIcon(Item item) => 
            Load<Sprite>($"Icons/{item.Name.ToLower()}");

        internal static Sprite GetBuildingIcon(Building target) =>
            Load<Sprite>($"Icons/{target.Name.ToLower()}");
    }
}