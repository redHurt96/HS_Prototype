using Prototype.Logic.Framework.UI;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    internal class StorehouseWindow : Window
    {
        [SerializeField] private TradeInventoryWindow _storehouseWindow;
        [SerializeField] private TradeInventoryWindow _playerInventoryWindow;

        private Inventory _storehouse;
        private Inventory _playerInventory;

        public override void Open(params object[] args)
        {
            _storehouse = (Inventory)args[0];
            _playerInventory = (Inventory)args[1];

            _storehouseWindow.SetInventory(_storehouse, MoveToPlayer);
            _playerInventoryWindow.SetInventory(_playerInventory, MoveToStorehouse);
            
            base.Open(args);
        }

        private void MoveToPlayer(ItemCell cell)
        {
            _playerInventory.Add(cell);
            _storehouse.Remove(cell);

            _playerInventory.InvokeUpdate();
            _storehouse.InvokeUpdate();
        }

        private void MoveToStorehouse(ItemCell cell)
        {
            _storehouse.Add(cell);
            _playerInventory.Remove(cell);

            _playerInventory.InvokeUpdate();
            _storehouse.InvokeUpdate();
        }
    }
}