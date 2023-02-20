using System;
using System.Collections.Generic;
using Prototype.Scripts.Interactables;
using UnityEngine;

namespace Prototype.Scripts.InventoryBehavior
{
    public class TradeInventoryWindow : MonoBehaviour
    {
        [SerializeField] private ItemUIView _prefab;
        
        [Space]
        [SerializeField] private Transform _anchor;
        
        private readonly List<ItemUIView> _views = new();
        
        private Inventory _origin;
        private Inventory _target;
        private Action<Item> _moveAction;

        public void SetInventory(Inventory origin, Action<Item> moveAction)
        {
            _moveAction = moveAction;
            _origin = origin;
        }

        private void OnEnable()
        {
            foreach (Item item in _origin.Items)
            {
                ItemUIView view = Instantiate(_prefab, _anchor);
                view.Setup(item);
                view.OnClick(() => _moveAction(item));
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