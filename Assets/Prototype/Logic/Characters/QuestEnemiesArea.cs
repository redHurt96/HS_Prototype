using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Quests;
using UnityEngine;

namespace Prototype.Logic.Characters
{
    public class QuestEnemiesArea : MonoBehaviour
    {
        [SerializeField] private List<Health> _healths;
        [SerializeField] private QuestsBehavior _questsBehavior;
        [SerializeField] private string _questKey;

        private void Start()
        {
            foreach (Health health in _healths) 
                health.OnDead += CheckAllDeaths;
        }

        private void CheckAllDeaths()
        {
            if (_healths.All(x => x == null || x.Current <= 0f) && _questsBehavior.CompareKey(_questKey))
                _questsBehavior.Receive(_questKey);
        }
    }
}