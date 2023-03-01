using TMPro;
using UnityEngine;

namespace Prototype.Logic.Interactables
{
    public abstract class ObserveUI<T> : MonoBehaviour 
        where T : ObserveBehavior
    {
        [SerializeField] protected T _observeBehavior;
        [SerializeField] private TextMeshProUGUI _itemDescription;

        private void Update()
        {
            _itemDescription.gameObject.SetActive(_observeBehavior.IsObserve);

            if (_observeBehavior.IsObserve) 
                _itemDescription.text = GetDescription();
        }

        protected abstract string GetDescription();
    }
}