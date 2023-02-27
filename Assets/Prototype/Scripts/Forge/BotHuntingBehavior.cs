using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Scripts.Forge
{
    public class BotHuntingBehavior : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _huntedBots = new();

        public void Hunt(GameObject bot)
        {
            if (!_huntedBots.Contains(bot))
                _huntedBots.Add(bot);
        }
    }
}