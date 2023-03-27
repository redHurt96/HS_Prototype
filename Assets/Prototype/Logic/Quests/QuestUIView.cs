using TMPro;
using UnityEngine;
using static System.String;

namespace Prototype.Logic.Quests
{
    public class QuestUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private QuestsBehavior _questsBehavior;

        private void Start()
        {
            _questsBehavior.Updated += UpdateDescription;
            
            UpdateDescription();
        }

        private void OnDestroy() => 
            _questsBehavior.Updated -= UpdateDescription;

        private void UpdateDescription() => 
            _description.text = _questsBehavior.HasAny 
                ? _questsBehavior.CurrentDescription 
                : Empty;
    }
}