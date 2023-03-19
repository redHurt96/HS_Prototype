using System;
using System.Collections.Generic;
using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.Construction
{
    [Serializable]
    public class ConstructionDesign
    {
        public bool BuildOnlyOnField => !string.IsNullOrEmpty(MineFieldName);
        
        public string Name;
        public ItemCell[] Materials;
        public string MineFieldName;

        [SerializeField] private List<Biome> _allowedBiome;

        public bool CanBuildInBiome(Biome biome) => 
            _allowedBiome.Contains(biome);
    }
}