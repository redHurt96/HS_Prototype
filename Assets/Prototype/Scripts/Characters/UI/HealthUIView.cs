using Prototype.Scripts.Character;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.Scripts.Characters.UI
{
    public class HealthUIView : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Slider _bar;

        private void Start()
        {
            _bar.maxValue = _health.Max;
            _bar.value = _health.Current;
        }

        private void Update() => 
            _bar.value = _health.Current;
    }
}
