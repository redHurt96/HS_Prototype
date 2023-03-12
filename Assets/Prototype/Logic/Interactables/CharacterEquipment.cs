using System;
using Prototype.Logic.Attributes;
using Prototype.Logic.Items;
using UnityEngine;
using static Prototype.Logic.Interactables.ResourcesService;

namespace Prototype.Logic.Interactables
{
    internal class CharacterEquipment : MonoBehaviour
    {
        public event Action Equipped; 
        public string ToolName => _currentTool?.ItemCell.ItemName;
        
        [SerializeField] private Transform _anchor;
        [SerializeField, ReadOnly] private ItemView _currentTool;
        
        public int GetPunchForce(MineItemView mineItemView) =>
            _currentTool != null 
                ? _currentTool.GetForce(mineItemView) 
                : 0;

        public void Equip(Item item)
        {
            if (_currentTool != null)
                Destroy(_currentTool.gameObject);

            _currentTool = Instantiate(GetItemPrefab(item.Name), _anchor.position, _anchor.rotation, _anchor);
            
            Equipped?.Invoke();
        }
    }
}