using Prototype.Logic.Attributes;
using Prototype.Logic.Interactables;
using UnityEngine;
using Zenject;
using static Cysharp.Threading.Tasks.UniTask;
using static Prototype_v2.Logic.Melee.AttackConfig;
using static UnityEngine.Input;
using static UnityEngine.Time;

namespace Prototype_v2.Logic.Melee
{
    public class MeleeFightBehavior : MonoBehaviour
    {
        private bool _passCooldown => _lastAttackTime + _currentAttack.NextComboAttackDelay < time;
        
        [SerializeField] private CharacterEquipment _characterEquipment;
        [SerializeField] private Animator _animator;

        private MeleeConfig _config;

        [SerializeField, ReadOnly] private AttackConfig _currentAttack;
        private float _lastAttackTime;

        [Inject]
        private void Construct(MeleeConfig meleeConfig)
        {
            _config = meleeConfig;
        }

        private void Update()
        {
            if (!_characterEquipment.HasSomeInHands)
                return;
            
            if (GetMouseButtonDown(0) && _passCooldown)
                Attack();
            else if (GetMouseButtonDown(1))
                Block();
        }

        private async void Attack()
        {
            Debug.Log("Attack");
            
            _currentAttack = _currentAttack is not { HasNext: true }
                ? _config.First
                : _config.Next(_currentAttack);

            _lastAttackTime = time;
            _animator.SetTrigger($"Attack_{_currentAttack.Order}");

            await Delay((int)(_currentAttack.DamageDelay * 1000));

            TrySendDamage();

            await Delay((int)((_currentAttack.BreakComboDelay - _currentAttack.DamageDelay) * 1000));

            if (_passCooldown)
                _currentAttack = Empty();
        }

        private void Block()
        {
            
        }

        private void TrySendDamage()
        {
            
        }
    }
}
