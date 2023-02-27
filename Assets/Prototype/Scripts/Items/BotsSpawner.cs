using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Application;
using static UnityEngine.Quaternion;
using static UnityEngine.Random;

namespace Prototype.Scripts.Items
{
    public class BotsSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _startItemsCount;
        [SerializeField] private float _spawnTime;

        private readonly List<GameObject> _bots = new();
        
        private IEnumerator Start()
        {
            for (int i = 0; i < _startItemsCount; i++) 
                Spawn();

            while (isPlaying)
            {
                yield return new WaitForSeconds(_spawnTime);

                _bots.RemoveAll(x => x == null);
                
                if (_bots.Count < _startItemsCount) 
                    Spawn();
            }
        }

        private void Spawn()
        {
            Vector3 position = new(Range(-15, 15), .9f, Range(-15, 15));
            GameObject bot = Instantiate(_prefab, position, identity);

            _bots.Add(bot);
        }
    }
}