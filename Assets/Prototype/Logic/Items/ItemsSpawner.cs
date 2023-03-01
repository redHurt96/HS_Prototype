using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Prototype.Logic.Items.ItemsFactory;
using static UnityEngine.Application;
using static UnityEngine.Physics;
using static UnityEngine.Random;

namespace Prototype.Logic.Items
{
    public class ItemsSpawner : MonoBehaviour
    {
        [SerializeField] private string[] _itemsNames;
        [SerializeField] private int _startItemsCount;
        [SerializeField] private float _spawnTime;
        [SerializeField] private Transform _origin;

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
            Vector3 position;
            
            do
            {
                position = _origin.position + new Vector3Int(Range(-15, 15), 0, Range(-15, 15));
            } while (!InCurrentLand(position));
            
            ItemView itemView = Create(itemName, position);

            _items.Add(itemView);
            
            //Log($"[ItemsSpawner] spawn {itemName} at {position}");
        }

        private bool InCurrentLand(Vector3 position) =>
            Raycast(position, Vector3.down, out RaycastHit hit)
            && hit.transform.IsChildOf(transform);
    }
}