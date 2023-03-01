using Prototype.Logic.Attributes;
using Prototype.Logic.Characters;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class BotFeedBehavior : MonoBehaviour
    {
        public bool IsAssignedToVillage => _village != null;

        [SerializeField, ReadOnly] private Village _village;
        [SerializeField] private Hunger _hunger;
        [SerializeField] private float _feedThreshold;

        private void Update()
        {
            if (_hunger.Current < _feedThreshold && _village != null) 
                _village.Feed(_hunger);
        }

        public void AssignVillage(Village village) => 
            _village = village;
    }
}