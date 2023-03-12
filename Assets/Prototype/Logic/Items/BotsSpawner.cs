using System.Collections.Generic;
using Prototype.Logic.Attributes;
using Prototype.Logic.Forge;
using UnityEngine;
using static System.Guid;
using static Prototype.Logic.Items.IslandUtilities;
using static Prototype.Logic.Items.LandSettings;
using static UnityEngine.Quaternion;
using static UnityEngine.Random;
using static UnityEngine.Resources;
using static UnityEngine.Vector3;

namespace Prototype.Logic.Items
{
    public class BotsSpawner : MonoBehaviour
    {
        [SerializeField] private BotsSpawningSettings _settings;
        [SerializeField] private Transform _origin;

        [SerializeField, ReadOnly] private List<Bot> _bots = new();
        
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
            Vector3 topPoint;

            do 
                position = _origin.position + new Vector3(Range(-scale, scale), .9f, Range(-scale, scale));
            while (!HasIslandBelowPoint(position, out island, out topPoint));
            
            Bot bot = Instantiate(Load<Bot>("Bot"), topPoint + up, identity, island.transform);

            bot.Name = NewGuid().ToString().Substring(0, 5);
            
            _bots.Add(bot);
        }
    }
}