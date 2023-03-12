using Prototype.Logic.Characters;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class BotFeedBehavior : MonoBehaviour
    {
        [SerializeField] private Bot _bot;
        [SerializeField] private Hunger _hunger;
        [SerializeField] private float _feedThreshold;

        private void Update()
        {
            if (_hunger.Current < _feedThreshold && _bot.IsAssignedToVillage) 
                _bot.Village.Feed(_hunger);
        }
    }
}