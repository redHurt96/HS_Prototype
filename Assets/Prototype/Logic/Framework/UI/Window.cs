using UnityEngine;

namespace Prototype.Logic.Framework.UI
{
    public abstract class Window : MonoBehaviour
    {
        public const string FORGE = "Forge Window";
        public const string FARM = "Farm Window";
        public const string STOREHOUSE = "Storehouse Window";

        public WindowName Name => _name;
        public bool Enabled => gameObject.activeSelf;

        [SerializeField] private WindowName _name;

        public virtual void Open(params object[] args) => 
            gameObject.SetActive(true);

        public void Close() => 
            gameObject.SetActive(false);
    }

    public enum WindowName
    {
        Inventory,
        Craft,
        Construction,
        Forge,
        Farm,
        Storehouse,
    }
}