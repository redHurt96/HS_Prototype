using System;
using Prototype.Scripts.Craft;

namespace Prototype.Scripts.Forge
{
    [Serializable]
    public struct ForgeRecipe
    {
        public Recipe Recipe;
        public int ClickCount;
    }
}