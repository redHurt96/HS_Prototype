using UnityEngine;

namespace Prototype.Logic.Items
{
    public class HideMineItem : MonoBehaviour
    {
        [SerializeField] private MineItemView _view;
        [SerializeField] private GameObject _objectToHide;

        private void Start() => 
            _view.Destroyed += Hide;

        private void OnDestroy() => 
            _view.Destroyed -= Hide;

        private void Hide()
        {
            if (_objectToHide != null)
                _objectToHide.SetActive(false);
            else
                _view.gameObject.SetActive(false);
        }
    }
}