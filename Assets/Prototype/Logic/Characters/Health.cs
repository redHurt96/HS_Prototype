using System;
using Prototype.Logic.Attributes;
using UnityEngine;

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
            _current = Mathf.Max(0f, _current - amount);

            if (Mathf.Approximately(_current, 0f)) 
                OnDead?.Invoke();
        }

        internal void Add(float amount) =>
            _current = Mathf.Min(Max, _current + amount);
    }
}
