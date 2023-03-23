using UnityEngine;

namespace Prototype.Logic.Items
{
    public class DestroyMineItem : MonoBehaviour
    {
        [SerializeField] private MineItemView _view;

        private void Start() => 
            _view.Destroyed += Destroy;

        private void OnDestroy() => 
            _view.Destroyed -= Destroy;

        private void Destroy() => 
            Destroy(_view.transform.gameObject);
    }
}