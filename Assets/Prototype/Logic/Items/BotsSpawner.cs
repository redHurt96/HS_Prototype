using System.Collections;
using System.Collections.Generic;
using Prototype.Logic.Forge;
using UnityEngine;
using static UnityEngine.Application;
using static UnityEngine.Physics;
using static UnityEngine.Quaternion;
using static UnityEngine.Random;

namespace Prototype.Logic.Items
{
    public class BotsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _origin;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _startItemsCount;
        [SerializeField] private float _spawnTime;

        private readonly List<GameObject> _bots = new();
        
        private IEnumerator Start()
        {
            for (int i = 0; i < _startItemsCount; i++) 
                Spawn();

            yield break;
            
            while (isPlaying)
            {
                yield return new WaitForSeconds(_spawnTime);

                _bots.RemoveAll(x => x == null || x.GetComponent<BotFeedBehavior>().IsAssignedToVillage);
                
                if (_bots.Count < _startItemsCount) 
                    Spawn();
            }
        }

        private void Spawn()
        {
            Vector3 position;

            do 
                position = _origin.position + new Vector3(Range(-15, 15), .9f, Range(-15, 15));
            while (!InCurrentLand(position));
            
            GameObject bot = Instantiate(_prefab, position, identity);

            _bots.Add(bot);
        }
        
        private bool InCurrentLand(Vector3 position) =>
            Raycast(position, Vector3.down, out RaycastHit hit)
            && hit.transform.IsChildOf(transform);
    }
}