using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Characters;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;
using static Prototype.Logic.Items.ItemsStorage;

namespace Prototype.Logic.Forge
{
    public class Village : MonoBehaviour
    {
        [SerializeField] private List<Inventory> _storehouses = new();

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

        public void RegisterStorehouse(Inventory inventory)
        {
            if (!_storehouses.Contains(inventory))
                _storehouses.Add(inventory);
        }
    }
}