using System;
using Prototype.Scripts.Craft;
using Prototype.Scripts.Interactables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Prototype.Scripts.Interactables.ResourcesService;

namespace Prototype.Scripts.InventoryBehavior
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

        public void Setup(Item item)
        {
            _image.sprite = GetItemIcon(item);
            _count.text = item.Count.ToString();
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