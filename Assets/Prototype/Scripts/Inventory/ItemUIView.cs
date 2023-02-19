using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ThirdPersonCharacterTemplate.Scripts.Interactables.ResourcesService;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    internal class ItemUIView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _count;
        
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
    }
}