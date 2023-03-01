using Prototype.Logic.Attributes;
using UnityEngine;
using static UnityEngine.LayerMask;
using static UnityEngine.Physics;

namespace Prototype.Logic.Interactables
{
    public class InteractionBehavior : MonoBehaviour
    {
        public bool IsObserve => ObservedObject != null;
        
        [ReadOnly] public GameObject ObservedObject;
        
        [SerializeField] private float _lenght = 10;
        
        private Camera _camera;

        private void Start() => 
            _camera = Camera.main;

        private void Update()
        {
            if (Raycast(_camera.transform.position, 
                    _camera.transform.forward, 
                    out RaycastHit hit, _lenght,
                    GetMask("Interactable")))
            {
                ObservedObject = hit.transform.gameObject;
            }
            else
            {
                ObservedObject = null;
            }
        }
    }
}