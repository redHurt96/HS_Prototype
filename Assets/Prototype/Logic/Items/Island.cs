using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Attributes;
using Prototype.Logic.Extensions;
using UnityEngine;

namespace Prototype.Logic.Items
{
    public class Island : MonoBehaviour
    {
        [ReadOnly] public string UniqueKey;
        public string StorageKey;
        public Biome Biome => _biome;
        public bool HasFreeDirection => _freeDirections.Any();
        public IReadOnlyList<float> FreeDirections => _freeDirections;
        public IReadOnlyDictionary<int, string> MineFields => _mineFields;

        [SerializeField, ReadOnly] private List<Island> _neighbours = new();

        [SerializeField] private Biome _biome;

        private readonly Dictionary<int, string> _mineFields = new();

        private readonly List<float> _freeDirections = new()
        {
            0,
            60,
            120,
            180,
            240,
            300
        };

        public float GetFreeDirection() => 
            _freeDirections.GetRandom();

        public void AddNeighbour(Island neighbour, float fromDirection)
        {
            if (_neighbours.Contains(neighbour))
                return;
            
            _freeDirections.Remove(fromDirection);
            _neighbours.Add(neighbour);
        }

        public void Register(int pointIndex, string itemName) => 
            _mineFields.Add(pointIndex, itemName);
    }
}