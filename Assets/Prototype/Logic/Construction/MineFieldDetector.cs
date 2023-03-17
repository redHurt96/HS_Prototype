using Prototype.Logic.Items;
using UnityEngine;
using static UnityEngine.Vector3;

namespace Prototype.Logic.Construction
{
    public class MineFieldDetector : MonoBehaviour
    {
        [SerializeField] private float _detectRange;
        [SerializeField] private CurrentIslandIdentifier _islandIdentifier;

        public bool HasProperMineFieldNearby(string mineFieldName)
        {
            Transform islandTransform = _islandIdentifier.Island.transform;

            foreach (Transform item in islandTransform)
            {
                if (!item.TryGetComponent(out MineFieldItemView view)
                    || view.Name != mineFieldName)
                    continue;
                
                if (view.IsBusy)
                    continue;
                
                float distance = Distance(item.position, transform.position);

                if (distance < _detectRange)
                    return true;
            }
            
            return false;
        }

        public MineFieldItemView GetProperMineFieldNearby(string mineFieldName)
        {
            Transform islandTransform = _islandIdentifier.Island.transform;

            foreach (Transform item in islandTransform)
            {
                if (!item.TryGetComponent(out MineFieldItemView view)
                    || view.Name != mineFieldName)
                    continue;
                
                if (view.IsBusy)
                    continue;
                
                float distance = Distance(item.position, transform.position);

                if (distance < _detectRange)
                    return view;
            }

            throw new($"Attempt to get mine even if they isn't ones");
        }
    }
}