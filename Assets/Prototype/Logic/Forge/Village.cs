using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Characters;
using Prototype.Logic.Craft;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;
using static Prototype.Logic.Items.ItemsStorage;

namespace Prototype.Logic.Forge
{
    public class Village : MonoBehaviour
    {
        public Vector3 Center => _center.position;
        
        [SerializeField] private List<Inventory> _storehouses = new();
        [SerializeField] private Transform _center;

        public void Feed(Hunger bot)
        {
            _storehouses.RemoveAll(x => x == null);
            
            Inventory targetStorehouse = _storehouses
                .Find(x => x.Cells.Any(y => y.ItemName == "food"));

            if (targetStorehouse == null)
                return;

            ItemCell cell = targetStorehouse.Cells.First(x => x.ItemName == "food");
            Item food = Get(cell.ItemName);

            bot.Feed(food.NutritionalValue);
            targetStorehouse.Remove(cell);
            targetStorehouse.InvokeUpdate();
        }

        public void TryRegister(Building building)
        {
            if (building.Name is "storehouse" or "farm" or "ice storehouse"
                && building.TryGetComponent(out Inventory inventory))
                RegisterStorehouse(inventory);
        }

        private void RegisterStorehouse(Inventory inventory)
        {
            if (!_storehouses.Contains(inventory))
                _storehouses.Add(inventory);
        }
    }
}