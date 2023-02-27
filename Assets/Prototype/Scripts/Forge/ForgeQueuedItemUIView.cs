using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Prototype.Scripts.Interactables.ResourcesService;

namespace Prototype.Scripts.Forge
{
    internal class ForgeQueuedItemUIView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _count;
        
        private ForgeCraftProcess _forgeCraftProcess;

        public void Setup(ForgeCraftProcess forgeCraftProcess)
        {
            _forgeCraftProcess = forgeCraftProcess;

            PerformUpdate();
        }

        private void PerformUpdate()
        {
            _image.sprite = GetItemIcon(_forgeCraftProcess.Target.ItemName);
            _count.text = _forgeCraftProcess.ClickCount.ToString();
        }
    }
}