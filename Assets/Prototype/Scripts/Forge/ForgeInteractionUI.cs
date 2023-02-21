using TMPro;
using UnityEngine;

namespace Prototype.Scripts.Forge
{
    public class ForgeInteractionUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _itemDescription;
        [SerializeField] private ForgeInteractionService _interactionService;

        private void Update()
        {
            _itemDescription.gameObject.SetActive(_interactionService.IsObserve);

            if (_interactionService.IsObserve)
            {
                _itemDescription.text = $"Forge - Interact (E)";
            }
        }
    }
}