using System.Collections.Generic;
using Prototype.Scripts.Interactables;
using Prototype.Scripts.Items;
using UnityEngine;

namespace Prototype.Scripts.InventoryBehavior
{
    public class InventoryWindow : MonoBehaviour
    {
        [SerializeField] private ItemUIView _prefab;
        
        [Space]
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Transform _anchor;
        
        private readonly List<ItemUIView> _views = new();

        public void SetInventory(Inventory inventory) => 
            _inventory = inventory;

        private void OnEnable()
        {
            foreach (Item item in _inventory.Items)
            {
                ItemUIView view = Instantiate(_prefab, _anchor);
                view.Setup(item);
                _views.Add(view);
            }
        }

        private void OnDisable()
        {
            foreach (ItemUIView view in _views) 
                Destroy(view.gameObject);
            
            _views.Clear();
        }
    }
}