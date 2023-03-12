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

        [SerializeField] private List<Bot> _huntedBots = new();
        [SerializeField] private Village _village;

        public void Hunt(Bot bot)
        {
            if (_huntedBots.Contains(bot)) 
                return;
            
            _huntedBots.Add(bot);

            bot.transform.position = _village.RandomizedCenter;
            
            Destroy(bot.GetComponent<DestroyOnDeadAction>());
            
            _village.RegisterSettler(bot);
        }

        public Bot Get()
        {
            Bot bot = _huntedBots[0];
            
            _huntedBots.RemoveAt(0);

            return bot;
        }
    }
}