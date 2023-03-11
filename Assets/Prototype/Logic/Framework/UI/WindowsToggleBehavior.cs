using Prototype.Logic.Items;
using UnityEngine;
using static Prototype.Logic.Items.UISettings;
using static UnityEngine.Input;

namespace Prototype.Logic.Framework.UI
{
    public class WindowsToggleBehavior : MonoBehaviour
    {
        [SerializeField] private WindowsRouter _windowsRouter;
        [SerializeField] private UISettings _uiSettings;

        private void Update()
        {
            foreach (WindowToggleGroup group in _uiSettings.Groups)
            {
                if (GetKeyDown(group.KeyCode))
                    _windowsRouter.Toggle(group.Window);
            }
        }
    }
}