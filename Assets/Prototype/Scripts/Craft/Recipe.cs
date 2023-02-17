using System;
using System.Collections.Generic;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    [Serializable]
    public struct Recipe
    {
        public Item Item;
        public List<Item> Ingredients;
    }
}