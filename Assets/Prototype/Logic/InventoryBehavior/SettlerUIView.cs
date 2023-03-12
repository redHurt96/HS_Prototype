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
        
        public void Setup(Bot bot)
        {
            _name.text = bot.Name;
            _job.text = "Unemployed";
            _buildingImage.enabled = false;
        }

        public void Setup(Bot bot, Building building)
        {
            _name.text = bot.Name;
            _job.text = building.Name;
            _buildingImage.sprite = GetBuildingIcon(building);
        }
    }
}