using Prototype.Logic.Attributes;
using UnityEngine;
using UnityEngine.AI;
using static Prototype.Logic.Quests.EnemyTargetLink;
using static UnityEngine.Color;
using static UnityEngine.Gizmos;
using static UnityEngine.Time;
using static UnityEngine.Vector3;

namespace Prototype.Logic.Quests
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private float _moveRadius;
        [SerializeField] private float _changeMoveTargetCooldown;
        
        [SerializeField, ReadOnly] private float _cooldown;
        [SerializeField, ReadOnly] private bool _isDetected;

        private Transform _transform;
        private Transform _target;

        private void Start()
        {
            _target = Target.transform;
            _transform = transform;
        }

        private void Update()
        {
            DetectTarget();
            
            if (_isDetected && _cooldown <= 0f)
                MoveToTarget();

            if (_cooldown > 0f)
                _cooldown -= deltaTime;
        }

        private void DetectTarget()
        {
            if (Distance(_transform.position, _target.transform.position) < _moveRadius) 
                _isDetected = true;
        }

        private void MoveToTarget()
        {
            _navMeshAgent.SetDestination(_target.transform.position);
            _cooldown = _changeMoveTargetCooldown;
        }

        private void OnDrawGizmos()
        {
            color = cyan;
            DrawWireSphere(transform.position, _moveRadius);
        }
    }
}