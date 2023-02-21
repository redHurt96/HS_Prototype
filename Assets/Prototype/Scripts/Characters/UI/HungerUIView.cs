using Prototype.Scripts.Character;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.Scripts.Characters.UI
{
    public class HungerUIView : MonoBehaviour
    {
        [SerializeField] private Hunger _hunger;
        [SerializeField] private Slider _bar;

        private void Start()
        {
            _bar.maxValue = _hunger.Max;
            _bar.value = _hunger.Current;
        }

        private void Update() =>
            _bar.value = _hunger.Current;
    }
}
