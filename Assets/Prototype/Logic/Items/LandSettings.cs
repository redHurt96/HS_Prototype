using UnityEngine;

namespace Prototype.Logic.Items
{
    [CreateAssetMenu(menuName = "Create LandSettings", fileName = "LandSettings", order = 0)]
    public class LandSettings : SingletonScriptableObject<LandSettings>
    {
        private const float ISLAND_WIDTH = 32f;

        public static float IslandWidth => Instance._islandWidth;
        public static float IslandMeshScaleCoefficient => Instance._islandWidth / ISLAND_WIDTH;
        public static float IslandSpawnDelay => Instance._islandSpawnDelay;
        public static Island OriginIsland => Instance._originIsland;
        public static Island[] Islands => Instance._prefabs;
        
        [SerializeField] private float _islandWidth = 32f;
        [SerializeField] private float _islandSpawnDelay = 120f;
        [SerializeField] private Island _originIsland;
        [SerializeField] private Island[] _prefabs;
    }
}