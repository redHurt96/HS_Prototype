using UnityEngine;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    public class HideAllWindowsAtStart : MonoBehaviour
    {
        [SerializeField] private AllWindowsReferences _windows;

        private void Awake()
        {
            foreach (GameObject window in _windows.Windows)
                window.SetActive(false);
        }
    }
}