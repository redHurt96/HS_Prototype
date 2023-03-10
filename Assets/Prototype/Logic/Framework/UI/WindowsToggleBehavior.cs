using System;
using UnityEngine;

namespace Prototype.Logic.Framework.UI
{
    public class WindowsToggleBehavior : MonoBehaviour
    {
        [SerializeField] private WindowsRouter _windowsRouter;
        [SerializeField] private WindowToggleGroup[] _groups;

        private void Update()
        {
            foreach (WindowToggleGroup group in _groups)
            {
                if (Input.GetKeyDown(group.KeyCode))
                    _windowsRouter.Toggle(group.Window);
            }
        }

        [Serializable]
        private class WindowToggleGroup
        {
            public WindowName Window;
            public KeyCode KeyCode;
        }
    }
}