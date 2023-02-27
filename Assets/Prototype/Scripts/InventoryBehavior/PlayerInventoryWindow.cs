using System.Collections.Generic;
using Prototype.Scripts.Character;
using Prototype.Scripts.Items;
using UnityEngine;
using static Prototype.Scripts.Items.ItemsStorage;

namespace Prototype.Scripts.InventoryBehavior
{
    public class PlayerInventoryWindow : MonoBehaviour
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
            foreach (ItemCell cell in _inventory.Items)
            {
                ItemUIView view = Instantiate(_prefab, _anchor);
                view.Setup(cell);
                _views.Add(view);

                Item item = Get(cell.ItemName);

                if (item.IsFood) 
                    view.OnClick(() => Feed(item));
            }
        }

        private void Feed(Item item)
        {
            _hunger.Feed(item.NutritionalValue);
            
            _inventory.Remove(item.Name, 1);
            _inventory.InvokeUpdate();
        }

        private void OnDisable()
        {
            foreach (ItemUIView view in _views) 
                Destroy(view.gameObject);
            
            _views.Clear();
        }
    }
}