using UnityEngine;
using static UnityEngine.Input;

namespace Prototype.Logic.Framework.UI
{
    public class WindowToggleBehavior : MonoBehaviour
    {
        [SerializeField] private GameObject _window;
        [SerializeField] private KeyCode _keyCode;

        private void Update()
        {
            if (GetKeyDown(_keyCode))
                _window.SetActive(!_window.activeSelf);
        }
    }
}