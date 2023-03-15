using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Extensions;
using Prototype.Logic.Forge;
using UnityEngine;
using static Prototype.Logic.Interactables.ResourcesService;
using static UnityEngine.Mathf;
using static UnityEngine.Quaternion;

namespace Prototype.Logic.Items
{
    public class MineFieldsSpawner : MonoBehaviour
    {
        [SerializeField] private Island _island;
        [SerializeField] private MineFieldsSpawnSettings _settings;
        [SerializeField] private List<Transform> _spawnPoints;

        private readonly List<Transform> _occupiedPoints = new();

        private void Start()
        {
            if (WorldDataHandler.Instance.HasData)
                return;
            
            for (int i = 0; i < Min(_settings.StartItemsCount, _spawnPoints.Count); i++) 
                Spawn();
        }

        public void Spawn(int pointIndex, string itemName)
        {
            Vector3 position = _spawnPoints[pointIndex].position;

            Instantiate(
                GetMineFieldPrefab(itemName), 
                position, 
                identity, 
                transform);

            _island.Register(pointIndex, itemName);
        }
        
        private void Spawn()
        {
            int index = _spawnPoints.IndexOf(_spawnPoints
                .Where(x => !_occupiedPoints.Contains(x))
                .ToArray()
                .GetRandom());
            
            string itemName = _settings.RandomItemName;
            
            Spawn(index, itemName);
            _occupiedPoints.Add(_spawnPoints[index]);
        }
    }
}