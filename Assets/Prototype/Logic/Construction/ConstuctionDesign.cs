using System;
using System.Collections.Generic;
using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.Construction
{
    [Serializable]
    public class ConstructionDesign
    {
        public string Name;
        public ItemCell[] Materials;
        
        [SerializeField] private List<Biome> _allowedBiome;

        public bool CanBuildInBiome(Biome biome) => 
            _allowedBiome.Contains(biome);
    }
}