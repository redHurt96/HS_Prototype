using System;
using Prototype.Logic.Craft;

namespace Prototype.Logic.Forge
{
    [Serializable]
    public struct ForgeRecipe
    {
        public Recipe Recipe;
        public int ClickCount;
    }
}