using Prototype.Scripts.Craft;
using Prototype.Scripts.Forge;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Prototype.Scripts.Interactables.ResourcesService;

namespace Prototype.Scripts.InventoryBehavior
{
    internal class FuelUIView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _clicksCount;
        
        private Fuel _fuel;

        public void Setup(Fuel fuel)
        {
            _fuel = fuel;
            _image.sprite = GetItemIcon(fuel.ItemCell.ItemName);
            
            PerformUpdate();
        }

        private void PerformUpdate() => 
            _clicksCount.text = _fuel.ForgeClickCount.ToString();
    }
}