using UnityEngine;
using static UnityEngine.Resources;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    public static class ResourcesService
    {
        public static Sprite GetItemIcon(Item item) => 
            Load<Sprite>($"Icons/{item.Name.ToLower()}");
    }
}