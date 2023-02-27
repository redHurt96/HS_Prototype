using UnityEngine;
using static UnityEngine.Camera;
using static UnityEngine.Input;
using static UnityEngine.KeyCode;
using static UnityEngine.LayerMask;
using static UnityEngine.Physics;

namespace Prototype.Scripts.Forge
{
    public class BotInteractionService : MonoBehaviour
    {
        public bool IsObserve => ObservedBot != null;
        
        [HideInInspector] public GameObject ObservedBot;

        [SerializeField] private BotHuntingBehavior _botHuntingBehavior;
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
                && hit.transform.CompareTag("Bot"))
            {
                ObservedBot = hit.transform.gameObject;
            }
            else
            {
                ObservedBot = null;
            }

            if (GetKeyDown(E) && ObservedBot != null)
                _botHuntingBehavior.Hunt(ObservedBot);
        }
    }
}