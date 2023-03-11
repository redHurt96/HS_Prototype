using System.Collections.Generic;
using Prototype.Logic.Characters;
using Prototype.Logic.Framework.UI;
using Prototype.Logic.Items;
using UnityEngine;
using static Prototype.Logic.Items.ItemsStorage;

namespace Prototype.Logic.InventoryBehavior
{
    public class PlayerInventoryWindow : Window
    {
        [SerializeField] private ItemUIView _prefab;
        
        [Space]
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Hunger _hunger;

        [Space]
        [SerializeField] private Transform _anchor;
        
        private readonly List<ItemUIView> _views = new();

        private void OnEnable()
        {
            _inventory.Updated += PerformUpdate;

            Setup();
        }

        private void OnDisable()
        {
            _inventory.Updated += PerformUpdate;

            Dispose();
        }

        private void Feed(Item item)
        {
            _hunger.Feed(item.NutritionalValue);
            
            _inventory.Remove(item.Name, 1);
            _inventory.InvokeUpdate();
        }

        private void PerformUpdate()
        {
            Dispose();
            Setup();
        }

        private void Setup()
        {
            foreach (ItemCell cell in _inventory.Cells)
            {
                ItemUIView view = Instantiate(_prefab, _anchor);
                view.Setup(cell);
                _views.Add(view);

                Item item = Get(cell.ItemName);

                if (item.IsFood)
                    view.OnClick(() => Feed(item));
            }
        }

        private void Dispose()
        {
            foreach (ItemUIView view in _views)
                Destroy(view.gameObject);

            _views.Clear();
        }
    }
}