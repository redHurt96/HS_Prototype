using Prototype.Logic.Forge;
using Prototype.Logic.InventoryBehavior;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.Scripts.Forge
{
    internal class FarmWindow : MonoBehaviour
    {
        [SerializeField] private StorehouseWindow _storehouseWindow;
        [SerializeField] private Button _farmButton;
        
        private Farm _farm;

        public void Show(Farm farm, Inventory playerInventory)
        {
            _farm = farm;
            _storehouseWindow.Show(farm.Inventory, playerInventory);
            _farmButton.onClick.AddListener(Farm);
            
            gameObject.SetActive(true);
        }

        public void Hide() => 
            gameObject.SetActive(false);

        private void Farm() => 
            _farm.PerformCraft();
    }
}