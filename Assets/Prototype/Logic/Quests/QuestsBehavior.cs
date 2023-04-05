using System;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Logic.Quests
{
    public class QuestsBehavior : MonoBehaviour
    {
        public event Action Updated;

        public bool HasAny => _quests.Count > 0;
        public string CurrentDescription => _current.Description;

        [SerializeField] private List<Quest> _quests;

        private Quest _current => _quests[0];

        public void Receive(string key)
        {
            if (!HasAny)
                throw new("Attempt to complete not current quest!");

            if (_current.Key == key)
            {
                _quests.RemoveAt(0);
                Updated?.Invoke();
            }
        }

        public bool CompareKey(string to) =>
            _current.Key == to;
    }
}