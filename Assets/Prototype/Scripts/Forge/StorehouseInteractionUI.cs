using TMPro;
using UnityEngine;

namespace Prototype.Scripts.Forge
{
    public class StorehouseInteractionUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _itemDescription;
        [SerializeField] private StorehouseInteractionService _interactionService;

        private void Update()
        {
            _itemDescription.gameObject.SetActive(_interactionService.IsObserve);

            if (_interactionService.IsObserve)
                _itemDescription.text = $"Storehouse - Interact (E)";
        }
    }
}