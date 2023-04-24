using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Quests
{
    [Serializable]
    internal class Quest
    {
        [SerializeField] private string _description;
        [SerializeField] private List<IGoal> _goals;
    }

    internal interface IGoal
    {
        string Description { get; }
    }

    public interface IQuestService
    {

    }

    public class QuestService : IQuestService
    {

    }
}