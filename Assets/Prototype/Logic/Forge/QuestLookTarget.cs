using Prototype.Logic.Attributes;
using Prototype.Logic.Quests;
using UnityEngine;
using static UnityEngine.Camera;
using static UnityEngine.Vector3;

namespace Prototype.Logic.Forge
{
    public class QuestLookTarget : MonoBehaviour
    {
        private static Camera _camera;

        [SerializeField] private QuestsBehavior _questsBehavior;
        [SerializeField] private float _threshold;
        [SerializeField] private string _key;
        [SerializeField, ReadOnly] private float _distanceToCenter;

        private void Start() => 
            _camera ??= main;

        private void Update()
        {
            if (!_questsBehavior.HasAny || _questsBehavior.CurrentKey != _key)
                return;
            
            Vector3 viewportPos = _camera.WorldToViewportPoint(transform.position);

            _distanceToCenter = Distance(viewportPos, new(0.5f, 0.5f, viewportPos.z));

            if (_distanceToCenter < _threshold)
            {
                _questsBehavior.Receive(_key);
                Destroy(gameObject);
            }
        }
    }
}