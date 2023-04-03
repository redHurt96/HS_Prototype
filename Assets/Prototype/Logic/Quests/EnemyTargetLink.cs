using UnityEngine;

namespace Prototype.Logic.Quests
{
    public class EnemyTargetLink : MonoBehaviour
    {
        public static GameObject Target { get; private set; }

        private void Awake() => 
            Target ??= GameObject.Find($"First Person Controller");
    }
}