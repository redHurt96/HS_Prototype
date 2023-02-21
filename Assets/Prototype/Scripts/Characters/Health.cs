using System;
using UnityEngine;

namespace Prototype.Scripts.Character
{
    public class Health : MonoBehaviour
    {
        public event Action OnDead;
        
        [SerializeField] private float _max;
        [SerializeField] private float _current;

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
    }
}
