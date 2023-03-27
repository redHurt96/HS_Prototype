using UnityEngine;
using static UnityEngine.Application;
using static UnityEngine.Color;
using static UnityEngine.Gizmos;

namespace Prototype.Logic.Quests
{
    public class QuestReachArea : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private string _questKey;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out QuestsBehavior questsBehavior)
                && questsBehavior.CurrentKey == _questKey)
            {
                questsBehavior.Receive(_questKey);
            }
        }

        private void OnDrawGizmos()
        {
            color = red;
            DrawWireSphere(transform.position, _radius);
        }
    }
}