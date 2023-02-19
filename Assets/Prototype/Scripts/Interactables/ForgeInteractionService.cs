using Prototype.Scripts.Craft;
using UnityEngine;
using static UnityEngine.Camera;
using static UnityEngine.Input;
using static UnityEngine.KeyCode;
using static UnityEngine.LayerMask;
using static UnityEngine.Physics;

namespace Prototype.Scripts.Interactables
{
    public class ForgeInteractionService : MonoBehaviour
    {
        public Forge ObservedBuilding;

        [SerializeField] private ForgeWindow _forgeWindow;
        [SerializeField] private InventoryBehavior.Inventory _playerInventory;
        [SerializeField] private float _lenght = 20;

        private Camera _camera;

        private void Start() =>
            _camera = main;

        private void Update()
        {
            if (Raycast(_camera.transform.position,
                    _camera.transform.forward,
                    out RaycastHit hit, _lenght,
                    GetMask("Interactable"))
                && hit.transform.TryGetComponent(out Forge forge))
            {
                ObservedBuilding = forge;
            }
            else
            {
                ObservedBuilding = null;

                if (_forgeWindow.gameObject.activeSelf)
                    _forgeWindow.Hide();
            }

            if (GetKeyDown(E) && ObservedBuilding != null)
                _forgeWindow.Show(ObservedBuilding, _playerInventory);
        }
    }
}