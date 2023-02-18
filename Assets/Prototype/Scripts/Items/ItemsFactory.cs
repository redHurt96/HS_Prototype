using System.Collections;
using System.Collections.Generic;
using ThirdPersonCharacterTemplate.Scripts.Interactables;
using UnityEngine;

public static class ItemsFactory
{
    public static void Create(string itemName, Vector3 position)
    {
        ItemView resource = Resources.Load<ItemView>($"Items/{itemName}");
        Object.Instantiate(resource, position, Quaternion.identity);
    }
}
