using System.Collections;
using Prototype.Scripts.Attributes;
using Prototype.Scripts.Character;
using UnityEngine;
using static UnityEngine.Application;

namespace Prototype.Scripts.Forge
{
    public class ForgeBotPlace : MonoBehaviour
    {
        public bool IsEmpty => _bot == null;
        
        [SerializeField] private Transform _botPlace;
        [SerializeField] private float _clickDelay;
        [SerializeField] private Forge _forge;
        
        [SerializeField, ReadOnly] private GameObject _bot;

        private IEnumerator Start()
        {
            yield return new WaitUntil(() => _bot != null);

            while (isPlaying)
            {
                yield return new WaitForSeconds(_clickDelay);
                
                if (_forge.CanCraft() && _bot != null)
                    _forge.PerformCraft();
            }
        }

        public void SetBot(GameObject bot)
        {
            _bot = bot;
            _bot.transform.position = _botPlace.position + Vector3.up * .9f;
        }
    }

    public class BotFeedBehavior : MonoBehaviour
    {
        [SerializeField] private Hunger _hunger;
        [SerializeField] private float _feedThreshold;
    }

    public class BotEmployeeAssignment : MonoBehaviour
    {
        
    }
}