using System;
using System.Collections.Generic;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    [Serializable]
    public class Recipe
    {
        public Item Item;
        public List<Item> Ingredients = new();
    }
}