using System;
using Prototype.Logic.Framework.UI;
using UnityEngine;

namespace Prototype.Logic.Items
{
    [CreateAssetMenu(menuName = "Create UISettings", fileName = "UISettings", order = 0)]
    public class UISettings : ScriptableObject
    {
        public WindowToggleGroup[] Groups;

        [Serializable]
        public class WindowToggleGroup
        {
            public WindowName Window;
            public KeyCode KeyCode;
        }
    }
}