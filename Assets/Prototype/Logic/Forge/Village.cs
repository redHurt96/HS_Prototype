using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Attributes;
using Prototype.Logic.Characters;
using Prototype.Logic.Craft;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;
using static Prototype.Logic.Items.IslandUtilities;
using static Prototype.Logic.Items.ItemsStorage;
using static UnityEngine.Debug;
using static UnityEngine.Random;
using static UnityEngine.Vector3;

namespace Prototype.Logic.Forge
{
    public class Village : MonoBehaviour
    {
        public Vector3 RandomizedCenter
        {
            get
            {
                Vector3 randomizedCenter = _center.position + new Vector3(Range(-5f, 5f), 0f, Range(-5f, 5f));

                HasIslandBelowPoint(randomizedCenter, out Island _, out Vector3 topPoint);
                
                return topPoint + up;
            }
        }

        public Transform BotsParent => _botsParent;
        public IReadOnlyList<Bot> Bots => _bots;
        public IReadOnlyList<Building> Buildings => _buildings;
        public Transform BuildingsParent => _buildingsParent;

        [SerializeField, ReadOnly] private List<Inventory> _storehouses = new();
        [SerializeField, ReadOnly] private List<Building> _buildings = new();
        [SerializeField, ReadOnly] private List<Bot> _bots = new();
        [SerializeField] private Transform _center;
        [SerializeField] private Transform _botsParent;
        [SerializeField] private Transform _buildingsParent;

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

        public void Register(Building building)
        {
            if (!Buildings.Contains(building))
            {
                _buildings.Add(building);
            
                if (building.Name is "storehouse" or "farm" or "ice storehouse"
                    && building.TryGetComponent(out Inventory inventory))
                    RegisterStorehouse(inventory);    
            }
            else
            {
                LogError("Attempt to register building which already registered in village");
            }
        }

        private void RegisterStorehouse(Inventory inventory)
        {
            if (!_storehouses.Contains(inventory))
                _storehouses.Add(inventory);
        }

        public void RegisterSettler(Bot bot)
        {
            if (!_bots.Contains(bot))
            {
                _bots.Add(bot);
                bot.AssignVillage(this);
            }
            else
            {
                LogError($"Attempt to add bot which already present in village");
            }
        }
    }
}