using Prototype.Logic.Characters;
using Prototype.Logic.Craft;
using Prototype.Logic.Forge;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Prototype.Logic.Interactables.ResourcesService;

namespace Prototype.Logic.InventoryBehavior
{
    public class SettlerUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _job;
        [SerializeField] private Image _buildingImage;
        [SerializeField] private Slider _health;
        [SerializeField] private Slider _hunger;
        
        public void Setup(Bot bot)
        {
            SetupCommon(bot);
            
            _job.text = "Unemployed";
            _buildingImage.enabled = false;
        }

        public void Setup(Bot bot, Building building)
        {
            SetupCommon(bot);
            
            _job.text = building.Name;
            _buildingImage.sprite = GetBuildingIcon(building);
        }

        private void SetupCommon(Bot bot)
        {
            _name.text = bot.Name;

            Health health = bot.GetComponent<Health>();
            Hunger hunger = bot.GetComponent<Hunger>();

            _health.maxValue = health.Max;
            _health.value = health.Current;
            
            _hunger.maxValue = hunger.Max;
            _hunger.value = hunger.Current;
        }
    }
}