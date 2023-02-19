using Prototype.Scripts.InventoryBehavior;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Prototype.Scripts.Interactables.ResourcesService;

namespace Prototype.Scripts.Interactables
{
    internal class ForgeQueuedItemUIView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _count;
        
        private CraftProcess _craftProcess;

        public void Setup(CraftProcess craftProcess)
        {
            _craftProcess = craftProcess;

            PerformUpdate();
        }

        public void PerformUpdate()
        {
            _image.sprite = GetItemIcon(_craftProcess.Target);
            _count.text = _craftProcess.ClickCount.ToString();
        }
    }
}