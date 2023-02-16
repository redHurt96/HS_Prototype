using UnityEngine;
using static UnityEngine.Camera;
using static UnityEngine.Input;
using static UnityEngine.Physics;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    public class InteractionService : MonoBehaviour
    {
        public Item ObservedItem => _observedItemView?.Item;

        [SerializeField] private Inventory _inventory;
        [SerializeField] private float _lenght = 20;

        private ItemView _observedItemView;
        private Camera _camera;

        private void Start()
        {
            _camera = main;
        }

        private void Update()
        {
            if (Raycast(_camera.transform.position, 
                    _camera.transform.forward, 
                    out RaycastHit hit, _lenght,
                    LayerMask.GetMask("Interactable")))
            {
                _observedItemView = hit.transform.GetComponent<ItemView>();
            }
            else
            {
                _observedItemView = null;
            }
            
            if (GetKeyDown(KeyCode.E) && _observedItemView != null)
            {
                _inventory.Add(ObservedItem);
                Destroy(_observedItemView.gameObject);
            }
        }
    }
}