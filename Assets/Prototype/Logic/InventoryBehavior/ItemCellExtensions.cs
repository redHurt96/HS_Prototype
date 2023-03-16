using Prototype.Logic.Interactables;
using Prototype.Logic.Items;

namespace Prototype.Logic.InventoryBehavior
{
    public static class ItemCellExtensions
    {
        public static void SetToFastAccess(this ItemCell item, FastAccessBehavior fastAccess) => 
            fastAccess.Put(item);
    }
}