using Prototype.Logic.Extensions;
using UnityEngine;

namespace Prototype.Logic.Items
{
    [CreateAssetMenu(menuName = "Create MineFieldsSpawnSettings", fileName = "MineFieldsSpawnSettings", order = 0)]
    public class MineFieldsSpawnSettings : ScriptableObject
    {
        public string RandomItemName => _itemsNames.GetRandom();
        public int StartItemsCount => _startItemsCount;
        
        [SerializeField] private string[] _itemsNames;
        [SerializeField] private int _startItemsCount;
    }
}