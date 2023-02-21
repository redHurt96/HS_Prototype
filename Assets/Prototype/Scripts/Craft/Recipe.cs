using System;
using System.Collections.Generic;
using Prototype.Scripts.Interactables;
using Prototype.Scripts.Items;

namespace Prototype.Scripts.Craft
{
    [Serializable]
    public struct Recipe
    {
        public Item Item;
        public List<Item> Ingredients;
    }
}