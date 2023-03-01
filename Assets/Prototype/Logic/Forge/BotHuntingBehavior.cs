using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class BotHuntingBehavior : MonoBehaviour
    {
        public bool HasAny
        {
            get
            {
                _huntedBots.RemoveAll(x => x == null);
                
                return _huntedBots.Count > 0;
            }
        }

        [SerializeField] private List<GameObject> _huntedBots = new();
        [SerializeField] private Village _village;

        public void Hunt(GameObject bot)
        {
            if (!_huntedBots.Contains(bot))
            {
                _huntedBots.Add(bot);
                bot
                    .GetComponent<BotFeedBehavior>()
                    .AssignVillage(_village);
            }
        }

        public GameObject Get()
        {
            GameObject bot = _huntedBots[0];
            
            _huntedBots.RemoveAt(0);

            return bot;
        }
    }
}