using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Prototype.Logic.Interactables.ResourcesService;
using static Prototype.Logic.Items.IslandUtilities;
using static Prototype.Logic.Items.LandSettings;
using static UnityEngine.Application;
using static UnityEngine.Quaternion;
using static UnityEngine.Random;

namespace Prototype.Logic.Items
{
    public class ItemsSpawner : MonoBehaviour
    {
        [SerializeField] private ItemsSpawningSettings _settings;
        [SerializeField] private Transform _origin;

        private readonly List<ItemView> _items = new();
        
        private IEnumerator Start()
        {
            yield return null;
            
            for (int i = 0; i < _settings.StartItemsCount; i++) 
                Spawn();

            while (isPlaying)
            {
                yield return new WaitForSeconds(_settings.SpawnTime);

                _items.RemoveAll(x => x == null);
                
                if (_items.Count < _settings.StartItemsCount) 
                    Spawn();
            }
        }

        private void Spawn()
        {
            Vector3 position;
            Vector3 topPoint;
            float scale = IslandWidth / 2f;
            Island island;
            
            do 
                position = _origin.position + new Vector3Int((int)Range(-scale, scale), 0, (int)Range(-scale, scale));
            while (!HasIslandBelowPoint(position, out island, out topPoint));
            
            ItemView itemView = Instantiate(
                GetItemPrefab(_settings.RandomItemName), 
                topPoint, 
                identity, 
                island.transform);

            _items.Add(itemView);
        }

    }
}