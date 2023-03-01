using Prototype.Scripts.Character;
using UnityEngine;

namespace Prototype.Scripts.Forge
{
    public class BotFeedBehavior : MonoBehaviour
    {
        [SerializeField] private Village _village;
        [SerializeField] private Hunger _hunger;
        [SerializeField] private float _feedThreshold;

        private void Update()
        {
            if (_hunger.Current < _feedThreshold && _village != null) 
                _village.Feed(_hunger);
        }

        public void AssignVillage(Village village)
        {
            _village = village;
        }
    }
}