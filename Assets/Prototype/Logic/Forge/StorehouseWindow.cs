using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    internal class StorehouseWindow : MonoBehaviour
    {
        [SerializeField] private TradeInventoryWindow _storehouseWindow;
        [SerializeField] private TradeInventoryWindow _playerInventoryWindow;

        private Inventory _storehouse;
        private Inventory _playerInventory;

        internal void Show(Inventory storeHouse, Inventory playerInventory)
        {
            _storehouse = storeHouse;
            _playerInventory = playerInventory;

            _storehouseWindow.SetInventory(storeHouse, MoveToPlayer);
            _playerInventoryWindow.SetInventory(playerInventory, MoveToStorehouse);

            gameObject.SetActive(true);
        }

        internal void Hide() =>
            gameObject.SetActive(false);

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