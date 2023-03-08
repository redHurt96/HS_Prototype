using UnityEngine;

namespace Prototype.Logic.Items
{
    [CreateAssetMenu(menuName = "Create BotsSpawningSettings", fileName = "BotsSpawningSettings", order = 0)]
    public class BotsSpawningSettings : ScriptableObject
    {
        public int StartItemsCount => _startItemsCount;
        
        [SerializeField] private int _startItemsCount;
    }
}