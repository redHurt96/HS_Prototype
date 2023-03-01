using UnityEngine;

namespace Prototype.Logic.Framework.UI
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