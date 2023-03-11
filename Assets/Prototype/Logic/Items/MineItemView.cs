using System;
using Prototype.Logic.Attributes;
using Prototype.Logic.InventoryBehavior;
using UnityEngine;

namespace Prototype.Logic.Items
{
    public class MineItemView : MonoBehaviour
    {
        public event Action Destroyed;
        
        public string Name => _name;

        [SerializeField] private int _breakForceStart;
        [SerializeField, ReadOnly] private int _breakForceCurrent;
        [SerializeField] private ItemCell _itemCell;
        [SerializeField] private string _name;

        private void Start() => 
            _breakForceCurrent = _breakForceStart;

        public void Punch(int withForce, Inventory characterInventory)
        {
            _breakForceCurrent = Mathf.Max(_breakForceCurrent - withForce, 0);

            if (_breakForceCurrent == 0)
            {
                characterInventory.Add(_itemCell);
                Destroyed?.Invoke();
            }
        }

        public void Restore()
        {
            _breakForceCurrent = _breakForceStart;
            gameObject.SetActive(true);
        }
    }
}