using UnityEngine;
using static UnityEngine.Input;
using static UnityEngine.KeyCode;

namespace Prototype.Logic.Framework.UI
{
    public class CloseOpenedWindowBehavior : MonoBehaviour
    {
        [SerializeField] private WindowsRouter _windowsRouter;

        private void Update()
        {
            if (GetKeyDown(Escape)) 
                _windowsRouter.CloseTopWindow();
        }
    }
}