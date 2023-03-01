using System;
using System.Collections.Generic;
using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.InventoryBehavior
{
    public class TradeInventoryWindow : MonoBehaviour
    {
        [SerializeField] private ItemUIView _prefab;
        
        [Space]
        [SerializeField] private Transform _anchor;

        private Inventory _origin;
        private Inventory _target;
        private Action<ItemCell> _moveAction;
        
        private readonly List<ItemUIView> _views = new();

        public void SetInventory(Inventory origin, Action<ItemCell> moveAction)
        {
            _moveAction = moveAction;
            _origin = origin;
        }

        private void OnEnable()
        {
            _origin.Updated += PerformUpdate;

            Setup();
        }

        private void OnDisable()
        {
            _origin.Updated -= PerformUpdate;

            Clear();
        }

        private void PerformUpdate()
        {
            Clear();
            Setup();
        }

        private void Setup()
        {
            foreach (ItemCell item in _origin.Cells)
            {
                ItemUIView view = Instantiate(_prefab, _anchor);
                view.Setup(item);
                view.OnClick(() => _moveAction(item));
                _views.Add(view);
            }
        }

        private void Clear()
        {
            foreach (ItemUIView view in _views)
                Destroy(view.gameObject);

            _views.Clear();
        }
    }
}