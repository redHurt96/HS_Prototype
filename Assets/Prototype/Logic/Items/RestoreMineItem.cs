using System.Collections;
using UnityEngine;

namespace Prototype.Logic.Items
{
    public class RestoreMineItem : MonoBehaviour
    {
        [SerializeField] private MineItemView _view;
        [SerializeField] private float _time;

        private void Start() => 
            _view.Destroyed += Restore;

        private void OnDestroy() => 
            _view.Destroyed -= Restore;

        private void Restore() =>
            StartCoroutine(RestoreRoutine());

        private IEnumerator RestoreRoutine()
        {
            yield return new WaitForSeconds(_time);
            
            _view.Restore();
        }
    }
}