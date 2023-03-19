using Prototype.Logic.Attributes;
using Prototype.Logic.Items;
using UnityEngine;
using static Prototype.Logic.Items.IslandUtilities;

namespace Prototype.Logic.Construction
{
    internal class CurrentIslandIdentifier : MonoBehaviour
    {
        public Biome Value => _value;
        public Island Island => _island;
        
        [SerializeField, ReadOnly] private Biome _value;
        [SerializeField, ReadOnly] private Island _island;

        private void Update()
        {
            if (HasIslandBelowPoint(transform.position, out _island, out Vector3 topPoint)) 
                _value = _island.Biome;
        }
    }
}