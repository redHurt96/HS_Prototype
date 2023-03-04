using UnityEngine;

namespace Prototype.Logic.Items
{
    public abstract class SingletonScriptableObject : ScriptableObject
    {
        public abstract void Install();
    }

    public abstract class SingletonScriptableObject<T> : SingletonScriptableObject where T : SingletonScriptableObject
    {
        protected static T Instance;

        public override void Install() =>
            Instance = this as T;
    }
}