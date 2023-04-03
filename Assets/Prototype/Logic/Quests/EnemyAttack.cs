using Prototype.Logic.Attributes;
using Prototype.Logic.Characters;
using UnityEngine;
using static Prototype.Logic.Quests.EnemyTargetLink;
using static UnityEngine.Color;
using static UnityEngine.Gizmos;
using static UnityEngine.Time;
using static UnityEngine.Vector3;

namespace Prototype.Logic.Quests
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float _attackRadius;
        [SerializeField] private float _cooldown;
        [SerializeField] private float _damage;
        
        [SerializeField, ReadOnly] private float _currentCooldown;

        private Health _health;
        
        private bool _closeEnough => Distance(transform.position, _health.transform.position) < _attackRadius;

        private void Start() => 
            _health = Target.GetComponent<Health>();

        private void Update()
        {
            if (_closeEnough && _currentCooldown <= 0f)
                Attack();

            if (_cooldown > 0f)
                _currentCooldown -= deltaTime;
        }

        private void Attack()
        {
            _health.Remove(_damage);
            _currentCooldown = _cooldown;
        }
        
        private void OnDrawGizmos()
        {
            color = red;
            DrawWireSphere(transform.position, _attackRadius);
        }
    }
}