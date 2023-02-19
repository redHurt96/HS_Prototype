using System;
using Prototype.Scripts.Interactables;

namespace Prototype.Scripts.Craft
{
    [Serializable]
    public class ConstructionDesign
    {
        public Building Target;
        public Item[] Materials;
    }
}