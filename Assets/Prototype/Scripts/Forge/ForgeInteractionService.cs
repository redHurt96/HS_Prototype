using UnityEngine;
using static UnityEngine.Camera;
using static UnityEngine.Input;
using static UnityEngine.KeyCode;
using static UnityEngine.LayerMask;
using static UnityEngine.Physics;

namespace Prototype.Scripts.Forge
{
    public class ForgeInteractionService : MonoBehaviour
    {
        public bool IsObserve => ObservedForge != null;
        
        [HideInInspector] public Forge ObservedForge;

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
                ObservedForge = forge;
            }
            else
            {
                ObservedForge = null;

                if (_forgeWindow.gameObject.activeSelf)
                    _forgeWindow.Hide();
            }

            if (GetKeyDown(E) && ObservedForge != null)
                _forgeWindow.Show(ObservedForge, _playerInventory);
        }
    }
}