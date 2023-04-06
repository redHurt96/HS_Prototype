using Prototype.Logic.Attributes;
using Prototype.Logic.Characters;
using UnityEngine;

namespace Prototype.Logic.InventoryBehavior
{
    public class MindRestorer : MonoBehaviour
    {
        [SerializeField] private Mind _mind;
        [SerializeField] private float _delayBeforeRestore;
        [SerializeField] private float _restorePerSec;
        
        [SerializeField, ReadOnly] private float _lastTime;
        [SerializeField, ReadOnly] private float _currentDelay;

        private void Start() => 
            _mind.Removed += SetLastRemoveTime;

        private void OnDestroy() => 
            _mind.Removed -= SetLastRemoveTime;

        private void Update()
        {
            if (Mathf.Approximately(_lastTime, 0f))
                return;

            if (_currentDelay < _delayBeforeRestore)
                _currentDelay += Time.deltaTime;
            
            if (_currentDelay > _delayBeforeRestore && _mind.LessThenMax)
                _mind.Add(_restorePerSec * Time.deltaTime);
        }

        private void SetLastRemoveTime() => 
            _lastTime = Time.time;
    }
}