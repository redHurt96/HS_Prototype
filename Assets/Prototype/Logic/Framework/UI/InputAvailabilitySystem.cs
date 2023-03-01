using System.Linq;
using ThirdPersonCharacterTemplate.Scripts;
using UnityEngine;

namespace Prototype.Logic.Framework.UI
{
    public class InputAvailabilitySystem : MonoBehaviour
    {
        [SerializeField] private AllWindowsReferences _windows;
        [SerializeField] private ThirdPersonController _thirdPersonController;
        
        private void Update()
        {
            bool isAnyWindowsShown = _windows.Windows.Any(x => x.activeSelf);

            Cursor.visible = isAnyWindowsShown;
            Cursor.lockState = isAnyWindowsShown
                ? CursorLockMode.None
                : CursorLockMode.Locked;

            _thirdPersonController.LockCameraPosition = isAnyWindowsShown;
        }
    }
}