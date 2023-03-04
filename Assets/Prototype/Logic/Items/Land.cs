using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Logic.Items
{
    public class Land : MonoBehaviour
    {
        public IReadOnlyList<Island> Islands => _islands;
        
        [SerializeField] private List<Island> _islands = new();

        public void Add(Island island) => 
            _islands.Add(island);
    }
}