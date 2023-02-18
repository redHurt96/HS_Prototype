using System.Collections;
using System.Collections.Generic;
using ThirdPersonCharacterTemplate.Scripts.Interactables;
using UnityEngine;

namespace Prototype.Scripts.Items
{
    public class ItemsSpawner : MonoBehaviour
    {
        [SerializeField] private string[] _itemsNames;
        [SerializeField] private int _startItemsCount;
        [SerializeField] private float _spawnTime;

        private List<ItemView> _items = new();
        
        private IEnumerator Start()
        {
            for (int i = 0; i < _startItemsCount; i++) 
                Spawn();

            while (Application.isPlaying)
            {
                yield return new WaitForSeconds(_spawnTime);

                if (_items.Count < _startItemsCount) 
                    Spawn();
            }
        }

        private void Spawn()
        {
            string itemName = _itemsNames[Random.Range(0, _itemsNames.Length)];
            Vector3 position = new(
                Random.Range(-15, 15),
                1f,
                Random.Range(-15, 15));

            ItemsFactory.Create(itemName, position);
        }
    }
}