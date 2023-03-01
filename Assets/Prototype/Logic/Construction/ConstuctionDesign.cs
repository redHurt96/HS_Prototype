using System;
using Prototype.Logic.Craft;
using Prototype.Logic.Items;

namespace Prototype.Logic.Construction
{
    [Serializable]
    public class ConstructionDesign
    {
        public Building Target;
        public ItemCell[] Materials;
    }
}