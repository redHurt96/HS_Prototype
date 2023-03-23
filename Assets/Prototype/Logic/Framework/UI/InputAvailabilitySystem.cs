using System.Linq;
using EasyBuildSystem.Examples.Bases.Scripts.FirstPerson;
using UnityEngine;
using static UnityEngine.Cursor;
using static UnityEngine.CursorLockMode;

namespace Prototype.Logic.Framework.UI
{
    public class InputAvailabilitySystem : MonoBehaviour
    {
        [SerializeField] private AllWindowsReferences _windows;
        [SerializeField] private Demo_FirstPersonCamera _camera;
        
        private void Update()
        {
            bool isAnyWindowsShown = _windows.Windows.Any(x => x.activeSelf);

            visible = isAnyWindowsShown;
            lockState = isAnyWindowsShown
                ? None
                : Locked;

            _camera.LockCursor = isAnyWindowsShown;
        }
    }
}