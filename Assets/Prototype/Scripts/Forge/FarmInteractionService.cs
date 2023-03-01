using Prototype.Scripts.InventoryBehavior;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Input;
using static UnityEngine.KeyCode;
using static UnityEngine.LayerMask;
using static UnityEngine.Physics;

namespace Prototype.Scripts.Forge
{
    public class FarmInteractionService : MonoBehaviour
    {
        public bool IsObserve => ObservedFarm != null;
        
        [HideInInspector] public Farm ObservedFarm;

        [SerializeField] private FarmWindow _farmWindow;
        [SerializeField] private Inventory _playerInventory;
        [SerializeField] private BotHuntingBehavior _botHuntingBehavior;
        [SerializeField] private float _lenght = 20;

        private Camera _camera;

        private void Start() =>
            _camera = Camera.main;

        private void Update()
        {
            if (Raycast(_camera.transform.position,
                    _camera.transform.forward,
                    out RaycastHit hit, _lenght,
                    GetMask("Interactable"))
                && hit.transform.TryGetComponent(out Farm forge))
            {
                ObservedFarm = forge;
            }
            else
            {
                ObservedFarm = null;

                if (_farmWindow.gameObject.activeSelf)
                    _farmWindow.Hide();
            }

            if (GetKeyDown(E) && ObservedFarm != null)
                _farmWindow.Show(ObservedFarm, _playerInventory);

            if (GetKeyDown(G)
                && ObservedFarm != null
                && ObservedFarm.TryGetComponent(out ProductionBuildingBotPlace place)
                && place.IsEmpty
                && _botHuntingBehavior.HasAny)
            {
                place.SetBot(_botHuntingBehavior.Get());
            }
        }
    }

    internal class FarmWindow : MonoBehaviour
    {
        [SerializeField] private StorehouseWindow _storehouseWindow;
        [SerializeField] private Button _farmButton;
        
        private Farm _farm;

        public void Show(Farm farm, Inventory playerInventory)
        {
            _farm = farm;
            _storehouseWindow.Show(farm.Inventory, playerInventory);
            _farmButton.onClick.AddListener(Farm);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Farm()
        {
            _farm.PerformCraft();
        }
    }
}