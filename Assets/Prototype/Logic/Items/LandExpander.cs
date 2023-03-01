using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Extensions;
using UnityEngine;
using static Unity.Mathematics.quaternion;
using static UnityEngine.Application;
using static UnityEngine.Color;
using static UnityEngine.Debug;
using static UnityEngine.Gizmos;
using static UnityEngine.Physics;
using static UnityEngine.Vector3;

namespace Prototype.Logic.Items
{
    public class LandExpander : MonoBehaviour
    {
        [SerializeField] private Transform _landsParent;
        [SerializeField] private float _spawnLandDelay = 120f;
        [SerializeField] private Land _origin;
        [SerializeField] private Land _prefab;

        private Dictionary<Transform, Land> _freeEdges = new();

        private IEnumerator Start()
        {
            foreach (Transform edge in _origin.Edges) 
                _freeEdges.Add(edge, _origin);

            while (isPlaying)
            {
                yield return new WaitForSeconds(_spawnLandDelay);

                AddLand();
            }
        }

        private void AddLand()
        {
            Transform edge = _freeEdges.Keys.ToList().GetRandom();

            _freeEdges.Remove(edge, out Land anchor);

            Vector3 newLandPosition = edge.position + (edge.position - anchor.Origin.position) + up * 2.5f;
            
            DrawLine(anchor.Origin.position, newLandPosition, green, 5f);
            
            Land newLand = Instantiate(_prefab, newLandPosition, identity, _landsParent);

            foreach (Transform newEdge in newLand.Edges)
            {
                Collider[] hits = OverlapSphere(newEdge.position, 1.5f);
                
                if (hits.Length == 1)
                    _freeEdges.Add(newEdge, newLand);
            }

            _freeEdges = _freeEdges
                .Where(x => OverlapSphere(x.Key.position, 1.5f).Length == 1)
                .ToDictionary(x => x.Key, y => y.Value);
        }

        private void OnDrawGizmos()
        {
            if (!isPlaying)
                return;
            
            color = magenta;

            foreach (Transform key in _freeEdges.Keys) 
                DrawSphere(key.position, 1.5f);
        }
    }
}