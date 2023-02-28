using System.Collections;
using Prototype.Scripts.Attributes;
using UnityEngine;
using static UnityEngine.Application;
using static UnityEngine.Mathf;

namespace Prototype.Scripts.Character
{
    public class Hunger : MonoBehaviour
    {
        public float Max => _max;
        public float Current => _current;

        [SerializeField] private Health _health;
        [Space]
        [SerializeField] private float _max;
        [SerializeField] private float _hungerDelay;
        [SerializeField] private float _hungerAmount;
        [SerializeField] private float _hungerHealthDamage;

        [SerializeField, ReadOnly] private float _current;

        private IEnumerator Start()
        {
            Reset();

            while (isPlaying)
            {
                yield return new WaitForSeconds(_hungerDelay);

                _current = Max(0f, _current - _hungerAmount);

                if (Approximately(_current, 0f)) 
                    _health.TakeDamage(_hungerHealthDamage);
            }
        }

        public void Reset() => 
            _current = _max;

        public void Feed(float amount) => 
            _current = Min(Max, _current + amount);
    }
}