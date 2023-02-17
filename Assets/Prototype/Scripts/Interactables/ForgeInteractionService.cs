using UnityEngine;
using static UnityEngine.Camera;
using static UnityEngine.Input;
using static UnityEngine.Physics;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    public class ForgeInteractionService : MonoBehaviour
    {
        public Forge ObservedBuilding;

        [SerializeField] private ForgeWindow _forgeWindow;
        [SerializeField] private float _lenght = 20;

        private Camera _camera;

        private void Start() =>
            _camera = main;

        private void Update()
        {
            if (Raycast(_camera.transform.position,
                    _camera.transform.forward,
                    out RaycastHit hit, _lenght,
                    LayerMask.GetMask("Interactable"))
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

            if (GetKeyDown(KeyCode.E) && ObservedBuilding != null)
            {
                _forgeWindow.Show(ObservedBuilding);
                Destroy(ObservedBuilding.gameObject);
            }
        }
    }
}