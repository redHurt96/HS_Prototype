using System.Collections.Generic;

namespace Prototype.Logic.Quests2
{
    public struct Quest
    {
        public List<IGoal> Goals;
    }

    public interface IGoal
    {
        string Description { get; }
    }

    public interface IQuestsService
    {
        
    }

    public class QuestsService : IQuestsService
    {
        
    }
}
