using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Extensions;
using UnityEngine;
using static CursorHandler;

namespace Prototype.Logic.Framework.UI
{
    public class WindowsRouter : MonoBehaviour
    {
        [SerializeField] private AllWindowsReferences _references;
        
        private IEnumerable<Window> _windows => _references
            .Windows
            .Where(x => x.HasComponent<Window>())
            .Select(x => x.GetComponent<Window>());
        
        
        public void Open(WindowName windowName, params object[] args)
        {
            foreach (Window window in _windows)
            {
                if (window.Name != windowName && window.Enabled)
                    window.Close();
                else if (window.Name == windowName && !window.Enabled && window.CanShow)
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
            {
                Open(windowName);
                SetState(false);
            }
            else
            {
                Close(windowName);
                SetState(true);
            }
        }

        public void CloseTopWindow()
        {
            foreach (Window window in _windows)
            {
                if (window.Enabled)
                    window.Close();
            }
            
            SetState(true);
        }
    }
}