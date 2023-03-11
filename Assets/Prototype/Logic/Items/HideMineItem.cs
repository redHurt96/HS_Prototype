using UnityEngine;

namespace Prototype.Logic.Items
{
    public class HideMineItem : MonoBehaviour
    {
        [SerializeField] private MineItemView _view;

        private void Start() => 
            _view.Destroyed += Hide;

        private void OnDestroy() => 
            _view.Destroyed -= Hide;

        private void Hide() => 
            _view.gameObject.SetActive(false);
    }
}