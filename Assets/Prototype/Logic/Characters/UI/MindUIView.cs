using UnityEngine;
using UnityEngine.UI;

namespace Prototype.Logic.Characters.UI
{
    public class MindUIView : MonoBehaviour
    {
        [SerializeField] private Mind _mind;
        [SerializeField] private Slider _bar;

        private void Start()
        {
            _bar.maxValue = _mind.Max;
            _bar.value = _mind.Current;
        }

        private void Update() => 
            _bar.value = _mind.Current;
    }
}