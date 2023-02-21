using System.Collections;
using UnityEngine;

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
        
        private float _current;

        private IEnumerator Start()
        {
            Reset();

            while (Application.isPlaying)
            {
                yield return new WaitForSeconds(_hungerDelay);

                if (Mathf.Approximately(_current, 0f)) 
                    _health.TakeDamage(_hungerAmount);
            }
        }

        public void Reset() => 
            _current = _max;

        public void Feed(float amount)
        {
            _current = Mathf.Min(0f, _current + amount);
        }
    }
}