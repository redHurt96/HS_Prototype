using Prototype.Scripts.Items;
using UnityEngine;
using static UnityEngine.Camera;
using static UnityEngine.Input;
using static UnityEngine.Physics;

namespace Prototype.Scripts.Interactables
{
    public class InteractionService : MonoBehaviour
    {
        public bool IsObserveItem => _observedItemView != null;
        public Item ObservedItem => _observedItemView.Item;

        [SerializeField] private InventoryBehavior.Inventory _inventory;
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
            
            if (GetKeyDown(KeyCode.E) && IsObserveItem)
            {
                _inventory.Add(ObservedItem);
                Destroy(_observedItemView.gameObject);
            }
        }
    }
}