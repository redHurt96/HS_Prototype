using Prototype.Scripts.InventoryBehavior;
using UnityEngine;

namespace Prototype.Scripts.Forge
{
    public class Farm : MonoBehaviour, IProductionBuilding
    {
        public Inventory Inventory => _inventory;
        
        [SerializeField] private Inventory _inventory;

        public bool CanCraft()
        {
            return true;
        }

        public void PerformCraft()
        {
            
        }
    }
}