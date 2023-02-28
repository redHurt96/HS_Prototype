using System;
using Prototype.Scripts.Craft;
using Prototype.Scripts.InventoryBehavior;
using UnityEngine;
using static UnityEngine.Camera;
using static UnityEngine.Input;
using static UnityEngine.KeyCode;
using static UnityEngine.LayerMask;
using static UnityEngine.Physics;

namespace Prototype.Scripts.Forge
{
    public class StorehouseInteractionService : MonoBehaviour
    {
        public bool IsObserve => ObservedStoreHouse != null;

        [HideInInspector] public Inventory ObservedStoreHouse;

        [SerializeField] private StorehouseWindow _storehouseWindow;
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
                && hit.transform.TryGetComponent(out Inventory storehouse)
                && hit.transform.TryGetComponent(out Building building)
                && building.Name.ToLower() == "storehouse")
            {
                ObservedStoreHouse = storehouse;
            }
            else
            {
                ObservedStoreHouse = null;

                if (_storehouseWindow.gameObject.activeSelf)
                    _storehouseWindow.Hide();
            }

            if (GetKeyDown(E) && ObservedStoreHouse != null)
                _storehouseWindow.Show(ObservedStoreHouse, _playerInventory);
        }
    }
}