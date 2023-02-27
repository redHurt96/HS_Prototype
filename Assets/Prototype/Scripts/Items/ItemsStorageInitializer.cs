using UnityEngine;

namespace Prototype.Scripts.Items
{
    public class ItemsStorageInitializer : MonoBehaviour
    {
        [SerializeField] private ItemsStorage _storage;

        private void Awake() => 
            _storage.InitSingleton();
    }
}