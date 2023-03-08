using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Extensions;
using Prototype.Logic.Forge;
using UnityEngine;
using static System.Guid;
using static Prototype.Logic.Forge.WorldData;
using static Prototype.Logic.Items.IslandUtilities;
using static Prototype.Logic.Items.LandSettings;
using static Unity.Mathematics.quaternion;
using static UnityEngine.Application;
using static UnityEngine.Vector3;

namespace Prototype.Logic.Items
{
    public class LandExpander : MonoBehaviour
    {
        public bool Loaded { get; private set; } = false;
        
        [SerializeField] private Transform _islandsParent;
        [SerializeField] private Land _land;

        private IEnumerator Start()
        {
            if (WorldDataHandler.Instance.HasData)
                RestoreSavedIslands();
            else
                CreateOriginLand();

            Loaded = true;
            
            while (isPlaying)
            {
                yield return new WaitForSeconds(IslandSpawnDelay);

                AddLand();
                UpdateNeighbours();
            }
        }

        private void RestoreSavedIslands()
        {
            foreach (IslandData island in WorldDataHandler.Instance.Data.Islands)
            {
                Island newIsland = CreateIsland(Islands.First(x => x.StorageKey == island.StorageKey), island.Position);
                newIsland.UniqueKey = island.UniqueKey;
                _land.Add(newIsland);
            }

            UpdateNeighbours();
        }

        private void CreateOriginLand()
        {
            Island newIsland = CreateIsland(OriginIsland, zero);
            newIsland.UniqueKey = NewGuid().ToString();
            _land.Add(newIsland);
        }

        private void AddLand()
        {
            Island islandToExpand = _land.Islands.First(x => x.HasFreeDirection);
            Vector3 origin = islandToExpand.transform.position;
            float direction = islandToExpand.GetFreeDirection();
            Vector3 newLandPosition = GetIslandPoint(origin, direction);
            
            Island newIsland = CreateIsland(Islands.GetRandom(), newLandPosition);
            newIsland.UniqueKey = NewGuid().ToString();
            
            islandToExpand.AddNeighbour(newIsland, direction);
            newIsland.AddNeighbour(islandToExpand, GetOpposite(direction));
            _land.Add(newIsland);
        }

        private void UpdateNeighbours()
        {
            List<(Island origin, float direction, Island target)> newNeighbours = new();
            
            foreach (Island island in _land.Islands)
            {
                foreach (float direction in island.FreeDirections)
                {
                    Vector3 newLandPoint = GetIslandPoint(island.transform.position, direction);

                    if (HasIslandAtPoint(newLandPoint, out Island foundIsland))
                        newNeighbours.Add((island, direction, foundIsland));
                }
            }

            foreach ((Island origin, float direction, Island target) tuple in newNeighbours)
            {
                tuple.origin.AddNeighbour(tuple.target, tuple.direction);
                tuple.target.AddNeighbour(tuple.origin, GetOpposite(tuple.direction));
            }
        }

        private Island CreateIsland(Island island, Vector3 position)
        {
            Island newIsland = Instantiate(island, position, identity, _islandsParent);

            newIsland.transform.GetChild(0).localScale *= IslandMeshScaleCoefficient;
            return newIsland;
        }
    }
}