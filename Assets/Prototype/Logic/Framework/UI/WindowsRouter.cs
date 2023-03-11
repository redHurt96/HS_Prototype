using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Prototype.Logic.Framework.UI
{
    public class WindowsRouter : MonoBehaviour
    {
        [SerializeField] private AllWindowsReferences _references;
        
        private IEnumerable<Window> _windows => _references
            .Windows
            .Select(x => x.GetComponent<Window>());
        
        
        public void Open(WindowName windowName, params object[] args)
        {
            foreach (Window window in _windows)
            {
                if (window.Name != windowName && window.Enabled)
                    window.Close();
                else if (window.Name == windowName && !window.Enabled)
                    window.Open(args);
            }
        }

        public void Close(WindowName windowName) => 
            _windows
                .First(x => x.Name == windowName)
                .Close();

        public void Toggle(WindowName windowName)
        {
            bool isWindowEnabled = _windows
                .First(x => x.Name == windowName)
                .Enabled;

            if (!isWindowEnabled) 
                Open(windowName);
            else
                Close(windowName);
        }

        public void CloseTopWindow()
        {
            foreach (Window window in _windows)
            {
                if (window.Enabled)
                    window.Close();
            }
        }
    }
}