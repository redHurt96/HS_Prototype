using System;
using Prototype.Logic.Attributes;
using UnityEngine;
using static UnityEngine.Mathf;

namespace Prototype.Logic.Characters
{
    public class Health : MonoBehaviour
    {
        public event Action OnDead;

        public float Max => _max;
        public float Current => _current;
        
        [SerializeField] private float _max;
        
        [SerializeField, ReadOnly] private float _current;

        private void Start() => 
            Reset();

        public void Reset() => 
            _current = _max;

        public void TakeDamage(float amount)
        {
            _current = Max(0f, _current - amount);

            if (Approximately(_current, 0f)) 
                OnDead?.Invoke();
        }

        internal void Add(float amount) =>
            _current = Min(Max, _current + amount);
    }
}
