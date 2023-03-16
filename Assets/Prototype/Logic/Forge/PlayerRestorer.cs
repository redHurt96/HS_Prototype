using Prototype.Logic.Interactables;
using Prototype.Logic.InventoryBehavior;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class PlayerRestorer : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private FastAccessBehavior _fastAccessBehavior;
        
        private void Start()
        {
            if (!WorldDataHandler.Instance.HasData)
                return;

            WorldData data = WorldDataHandler.Instance.Data;
            
            _inventory.Set(data.PlayerInventory);
            _fastAccessBehavior.Set(data.PlayerFastAccess);
        }
    }
}