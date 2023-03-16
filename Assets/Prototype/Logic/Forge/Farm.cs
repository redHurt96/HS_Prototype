using Prototype.Logic.Attributes;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class Farm : MonoBehaviour, IProductionBuilding
    {
        public Inventory Inventory => _inventory;

        [SerializeField] private ItemCell _itemCell;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private int _clicksToCraft;
        [SerializeField, ReadOnly] private int _clicksLeft;

        private void Awake() => 
            _clicksLeft = _clicksToCraft;

        public bool CanCraft() => 
            true;

        public void PerformCraft()
        {
            _clicksLeft--;

            if (_clicksLeft is 0)
            {
                _clicksLeft = _clicksToCraft;
                
                _inventory.Add(_itemCell);
                _inventory.InvokeUpdate();
            }
        }
    }
}