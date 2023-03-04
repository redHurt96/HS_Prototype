using UnityEngine;

namespace Prototype.Logic.Items
{
    public class ConfigsInstaller : MonoBehaviour
    {
        [SerializeField] private SingletonScriptableObject[] _configs;

        private void Awake()
        {
            foreach (SingletonScriptableObject config in _configs) 
                config.Install();
        }
    }
}