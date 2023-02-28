using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Scripts.Forge
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

        public void Hunt(GameObject bot)
        {
            if (!_huntedBots.Contains(bot))
                _huntedBots.Add(bot);
        }

        public GameObject Get()
        {
            GameObject bot = _huntedBots[0];
            
            _huntedBots.RemoveAt(0);

            return bot;
        }
    }
}