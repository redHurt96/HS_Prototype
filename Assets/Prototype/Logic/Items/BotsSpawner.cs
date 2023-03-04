using System.Collections;
using System.Collections.Generic;
using Prototype.Logic.Attributes;
using Prototype.Logic.Forge;
using UnityEngine;
using static Prototype.Logic.Items.IslandUtilities;
using static Prototype.Logic.Items.LandSettings;
using static UnityEngine.Application;
using static UnityEngine.Physics;
using static UnityEngine.Quaternion;
using static UnityEngine.Random;

namespace Prototype.Logic.Items
{
    public class BotsSpawner : MonoBehaviour
    {
        [SerializeField] private BotsSpawningSettings _settings;
        [SerializeField] private Transform _origin;

        [SerializeField, ReadOnly] private List<GameObject> _bots = new();
        
        private void Start()
        {
            for (int i = 0; i < _settings.StartItemsCount; i++) 
                Spawn();
        }

        private void Spawn()
        {
            Vector3 position;
            float scale = IslandWidth / 2f;
            Island island;

            do 
                position = _origin.position + new Vector3(Range(-scale, scale), .9f, Range(-scale, scale));
            while (!HasIslandBelowPoint(position, out island));
            
            GameObject bot = Instantiate(_settings.Prefab, position, identity, island.transform);

            _bots.Add(bot);
        }
        
        private bool InCurrentLand(Vector3 position) =>
            Raycast(position, Vector3.down, out RaycastHit hit)
            && hit.transform.IsChildOf(transform);
    }
}