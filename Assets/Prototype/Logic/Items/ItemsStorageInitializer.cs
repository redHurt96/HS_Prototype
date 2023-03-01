using UnityEngine;

namespace Prototype.Logic.Items
{
    public class ItemsStorageInitializer : MonoBehaviour
    {
        [SerializeField] private ItemsStorage _storage;

        private void Awake() => 
            _storage.InitSingleton();
    }
}