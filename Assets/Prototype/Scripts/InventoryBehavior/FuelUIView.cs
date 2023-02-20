using Prototype.Scripts.Craft;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Prototype.Scripts.Interactables.ResourcesService;

namespace Prototype.Scripts.InventoryBehavior
{
    internal class FuelUIView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _count;
        [SerializeField] private TextMeshProUGUI _clicksCount;
        
        private Fuel _fuel;

        public void Setup(Fuel fuel)
        {
            _fuel = fuel;
            _image.sprite = GetItemIcon(fuel.Item);
            
            PerformUpdate();
        }

        public void PerformUpdate()
        {
            _count.text = _fuel.Item.Count.ToString();
            _clicksCount.text = _fuel.ForgeClickCount.ToString();
        }
    }
}