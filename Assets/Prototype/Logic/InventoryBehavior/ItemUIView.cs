using System;
using Prototype.Logic.Craft;
using Prototype.Logic.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Prototype.Logic.Interactables.ResourcesService;

namespace Prototype.Logic.InventoryBehavior
{
    internal class ItemUIView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _count;
        [SerializeField] private Button _button;
        
        private Action _onClick;

        private void Awake() => 
            _button.onClick
                .AddListener(() => _onClick?.Invoke());

        public void Setup(ItemCell cell)
        {
            _image.sprite = GetItemIcon(cell.ItemName);
            _count.gameObject.SetActive(true);
            _count.text = cell.Count.ToString();
        }

        internal void Setup(Building target)
        {
            _image.sprite = GetBuildingIcon(target);
            _count.gameObject.SetActive(false);
        }

        public void OnClick(Action action) => 
            _onClick = action;
    }
}