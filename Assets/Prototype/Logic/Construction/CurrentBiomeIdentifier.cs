using Prototype.Logic.Attributes;
using Prototype.Logic.Items;
using UnityEngine;
using static Prototype.Logic.Items.IslandUtilities;

namespace Prototype.Logic.Construction
{
    internal class CurrentBiomeIdentifier : MonoBehaviour
    {
        public Biome Value => _value;
        
        [SerializeField, ReadOnly] private Biome _value;

        private void Update()
        {
            if (HasIslandBelowPoint(transform.position, out Island island, out Vector3 topPoint)) 
                _value = island.Biome;
        }
    }
}