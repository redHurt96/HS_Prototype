using System;
using System.Collections.Generic;
using Prototype.Scripts.Interactables;
using Prototype.Scripts.Items;

namespace Prototype.Scripts.Craft
{
    [Serializable]
    public struct Recipe
    {
        public ItemCell Item;
        public List<ItemCell> Ingredients;
    }
}