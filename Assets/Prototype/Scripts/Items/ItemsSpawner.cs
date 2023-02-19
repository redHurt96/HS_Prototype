using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Prototype.Scripts.Interactables;
using UnityEngine;
using static Prototype.Scripts.Items.ItemsFactory;
using static UnityEngine.Application;
using static UnityEngine.Debug;
using static UnityEngine.Random;

namespace Prototype.Scripts.Items
{
    public class ItemsSpawner : MonoBehaviour
    {
        [SerializeField] private string[] _itemsNames;
        [SerializeField] private int _startItemsCount;
        [SerializeField] private float _spawnTime;

        private readonly List<ItemView> _items = new();
        
        private IEnumerator Start()
        {
            for (int i = 0; i < _startItemsCount; i++) 
                Spawn();

            while (isPlaying)
            {
                yield return new WaitForSeconds(_spawnTime);

                _items.RemoveAll(x => x == null);
                
                if (_items.Count < _startItemsCount) 
                    Spawn();
            }
        }

        private void Spawn()
        {
            string itemName = _itemsNames[Range(0, _itemsNames.Length)];
            Vector3 position = new(Range(-15, 15), 0f, Range(-15, 15));
            ItemView itemView = Create(itemName, position);

            _items.Add(itemView);
            
            //Log($"[ItemsSpawner] spawn {itemName} at {position}");
        }
    }
}