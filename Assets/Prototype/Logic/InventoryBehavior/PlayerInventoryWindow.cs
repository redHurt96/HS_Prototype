using System.Collections.Generic;
using Prototype.Logic.Characters;
using Prototype.Logic.Framework.UI;
using Prototype.Logic.Interactables;
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
        [SerializeField] private Health _health;
        [SerializeField] private Mind _mind;
        [SerializeField] private CharacterEquipment _equipment;
        [SerializeField] private FastAccessBehavior _fastAccess;

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
                    view.OnClick(() => item.Feed(_hunger, _health, _mind, _inventory));
                else if (item.CanHoldInHands)
                    view.OnClick(() => item.Equip(_equipment));
                
                view.OnRightClick(() => cell.SetToFastAccess(_fastAccess));
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