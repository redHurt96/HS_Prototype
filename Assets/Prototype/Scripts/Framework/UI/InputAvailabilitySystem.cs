using System.Linq;
using UnityEngine;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    public class InputAvailabilitySystem : MonoBehaviour
    {
        [SerializeField] private AllWindowsReferences _windows;
        
        private void Update()
        {
            bool isUiShown = _windows.Windows.Any(x => x.activeSelf);

            Cursor.visible = isUiShown;
            Cursor.lockState = isUiShown
                ? CursorLockMode.None
                : CursorLockMode.Locked;
        }
    }
}