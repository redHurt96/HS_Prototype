using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ThirdPersonCharacterTemplate.Scripts.Interactables.ResourcesService;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    internal class ForgeItemUIView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _countDown;

        private CraftProcess _craftProcess;

        public void Setup(CraftProcess craftProcess)
        {
            _craftProcess = craftProcess;

            _image.sprite = GetItemIcon(craftProcess.Target);
        }

        private void Update() =>
            _countDown.text = _craftProcess.RemainingTime.ToString();
    }
}