using System;
using System.Collections.Generic;
using Prototype.Logic.Items;

namespace Prototype.Logic.Craft
{
    [Serializable]
    public struct Recipe
    {
        public ItemCell Item;
        public List<ItemCell> Ingredients;
    }
}