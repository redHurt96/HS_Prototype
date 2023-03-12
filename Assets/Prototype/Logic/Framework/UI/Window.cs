using UnityEngine;

namespace Prototype.Logic.Framework.UI
{
    public abstract class Window : MonoBehaviour
    {
        public WindowName Name => _name;
        public bool Enabled => gameObject.activeSelf;

        [SerializeField] private WindowName _name;

        public virtual void Open(params object[] args) => 
            gameObject.SetActive(true);

        public void Close() => 
            gameObject.SetActive(false);
    }
}