using System;
using Prototype.Scripts.Craft;

namespace Prototype.Scripts.Interactables
{
    [Serializable]
    public struct ForgeRecipe
    {
        public Recipe Recipe;
        public int ClickCount;
    }
}