using Prototype.Logic.Extensions;
using UnityEngine;

namespace Prototype.Logic.Items
{
    [CreateAssetMenu(menuName = "Create ItemsSpawningSettings", fileName = "ItemsSpawningSettings", order = 0)]
    public class ItemsSpawningSettings : ScriptableObject
    {
        public string RandomItemName => _itemsNames.GetRandom();
        
        public int StartItemsCount => _startItemsCount;
        public float SpawnTime => _spawnTime;
        
        [SerializeField] private string[] _itemsNames;
        [SerializeField] private int _startItemsCount;
        [SerializeField] private float _spawnTime;
    }
}