using Prototype.Logic.Quests;
using UnityEngine;

namespace Prototype.Logic.InventoryBehavior
{
    public class InventoryQuestBehavior : MonoBehaviour
    {
        [SerializeField] private QuestsBehavior _questsBehavior;

        private void Start() => 
            ItemExtensions.Used += SendKeyIfQuestItemUsed;

        private void OnDestroy() => 
            ItemExtensions.Used -= SendKeyIfQuestItemUsed;

        private void SendKeyIfQuestItemUsed(string itemName)
        {
            string questKey = $"use_{itemName}";

            if (_questsBehavior.HasAny && _questsBehavior.CompareKey(questKey)) 
                _questsBehavior.Receive(questKey);
        }
    }
}