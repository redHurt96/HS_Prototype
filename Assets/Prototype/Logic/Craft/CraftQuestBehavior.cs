using Prototype.Logic.Quests;
using UnityEngine;

namespace Prototype.Logic.Craft
{
    public class CraftQuestBehavior : MonoBehaviour
    {
        [SerializeField] private CraftBehavior _craftBehavior;
        [SerializeField] private QuestsBehavior _questsBehavior;

        private void Start() => 
            _craftBehavior.Crafted += TrySendQuestKey;

        private void OnDestroy() => 
            _craftBehavior.Crafted -= TrySendQuestKey;

        private void TrySendQuestKey(string itemName)
        {
            string key = $"make_{itemName}";
            
            if (_questsBehavior.HasAny && _questsBehavior.CompareKey(key))
                _questsBehavior.Receive(key);
        }
    }
}