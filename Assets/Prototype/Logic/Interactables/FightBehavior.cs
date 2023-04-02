using Prototype.Logic.Attributes;
using UnityEngine;
using static UnityEngine.Animator;
using static UnityEngine.Input;
using static UnityEngine.Time;

namespace Prototype.Logic.Interactables
{
    public class FightBehavior : MonoBehaviour
    {
        public bool InCooldown => _currentCooldown > 0;
        
        [SerializeField] private CharacterEquipment _characterEquipment;
        [SerializeField] private Animator _punchAnimator;
        [SerializeField] private float _cooldownTime = 1f;

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
        }
    }
}