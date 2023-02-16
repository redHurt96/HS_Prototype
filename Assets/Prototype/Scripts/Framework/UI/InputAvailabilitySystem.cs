using System.Linq;
using UnityEngine;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    public class InputAvailabilitySystem : MonoBehaviour
    {
        [SerializeField] private GameObject[] _windows;
        
        private void Update()
        {
            bool isUiShown = _windows.Any(x => x.activeSelf);

            Cursor.visible = isUiShown;
            Cursor.lockState = isUiShown
                ? CursorLockMode.None
                : CursorLockMode.Locked;
        }
    }
}