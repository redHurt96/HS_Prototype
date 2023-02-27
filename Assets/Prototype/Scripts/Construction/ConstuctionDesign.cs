using System;
using Prototype.Scripts.Craft;
using Prototype.Scripts.Items;

namespace Prototype.Scripts.Construction
{
    [Serializable]
    public class ConstructionDesign
    {
        public Building Target;
        public ItemCell[] Materials;
    }
}