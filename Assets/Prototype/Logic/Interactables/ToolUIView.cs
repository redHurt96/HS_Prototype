using UnityEngine;
using UnityEngine.UI;
using static Prototype.Logic.Interactables.ResourcesService;

namespace Prototype.Logic.Interactables
{
    internal class ToolUIView : MonoBehaviour
    {
        [SerializeField] private CharacterEquipment _equipment;
        [Space] 
        [SerializeField] private Image _image;

        private void Start() => 
            _equipment.Equipped += UpdateView;

        private void OnDestroy() => 
            _equipment.Equipped -= UpdateView;

        private void UpdateView() => 
            _image.sprite = GetItemIcon(_equipment.ToolName);
    }
}