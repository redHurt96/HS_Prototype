using Prototype.Logic.Forge;
using Prototype.Logic.Framework.UI;
using Prototype.Logic.InventoryBehavior;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.Scripts.Forge
{
    internal class FarmWindow : Window
    {
        [SerializeField] private StorehouseWindow _storehouseWindow;
        [SerializeField] private Button _farmButton;
        
        private Farm _farm;

        public override void Open(params object[] args)
        {
            _farm = (Farm)args[0];
            _storehouseWindow.Open(_farm.Inventory, (Inventory)args[1]);
            _farmButton.onClick.AddListener(Farm);
            
            base.Open(args);
        }

        private void Farm() => 
            _farm.PerformCraft();
    }
}