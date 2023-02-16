using UnityEngine;
using static UnityEngine.Input;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
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