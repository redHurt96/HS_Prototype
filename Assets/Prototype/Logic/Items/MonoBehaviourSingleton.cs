using UnityEngine;

namespace Prototype.Logic.Items
{
    public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    T[] instances = (T[])FindObjectsOfType(typeof(T));

                    if (instances.Length == 0)
                    {
                        Debug.LogError($"Нет ни одного экземпляра {typeof(T)} на сцене!");
                        return null;
                    }

                    if (instances.Length > 1)
                    {
                        Debug.LogError($"На сцене больше одного экземпляра {typeof(T)}");
                        return null;
                    }

                    instance = instances[0];
                    return instance;
                }

                return instance;
            }
        }
    }
}