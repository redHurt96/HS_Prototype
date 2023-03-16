using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Prototype.Logic.Interactables
{
    internal class FastAccessItemUIView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private FastAccessBehavior _fastAccessBehavior;
        [SerializeField] private Image _image;

        private int? _index;

        public void Setup(int index, Sprite icon)
        {
            _index = index;
            _image.sprite = icon;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right && _index != null) 
                _fastAccessBehavior.Clear((int)_index);
        }

        public void Clear()
        {
            _index = null;
            _image.sprite = null;
        }
    }
}