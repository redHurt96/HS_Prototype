using System;
using Prototype.Logic.Attributes;
using Prototype.Logic.Characters;
using UnityEngine;
using static UnityEngine.Animator;
using static UnityEngine.Input;
using static UnityEngine.Physics;
using static UnityEngine.Time;

namespace Prototype.Logic.Interactables
{
    public class FightBehavior : MonoBehaviour
    {
        public bool InCooldown => _currentCooldown > 0;
        public event Action Attacked; 

        [SerializeField] private Health _characterHealth;
        [SerializeField] private CharacterEquipment _characterEquipment;
        [SerializeField] private Animator _punchAnimator;
        [SerializeField] private Transform _punchAnchor;
        [SerializeField] private float _cooldownTime = 1f;
        [SerializeField] private float _attackRadius = 1f;
        [SerializeField] private float _damage = 15f;

        [SerializeField, ReadOnly] private float _currentCooldown;

        private static readonly int _punch = StringToHash("Punch");

        private void Update()
        {
            if (GetMouseButtonDown(0) && _characterEquipment.HasSomeInHands && !InCooldown)
                Punch();

            if (_currentCooldown > 0f)
                _currentCooldown -= deltaTime;
        }

        private void Punch()
        {
            _punchAnimator.SetTrigger(_punch);
            _currentCooldown = _cooldownTime;

            Collider[] colliders = OverlapSphere(_punchAnchor.position, _attackRadius);

            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out Health health) && health != _characterHealth) 
                    health.TakeDamage(_damage);
            }
            
            Attacked?.Invoke();
        }
    }
}