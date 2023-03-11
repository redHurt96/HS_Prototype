using System.Collections.Generic;
using Prototype.Logic.Characters;
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
                
                Destroy(bot.GetComponent<DestroyOnDeadAction>());

                bot.transform.position =
                    _village.Center + new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
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