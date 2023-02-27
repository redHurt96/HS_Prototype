using Prototype.Scripts.Items;
using TMPro;
using UnityEngine;

namespace Prototype.Scripts.Interactables
{
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _itemDescription;
        [SerializeField] private InteractionService _interactionService;

        private void Update()
        {
            _itemDescription.gameObject.SetActive(_interactionService.IsObserveItem);

            if (_interactionService.IsObserveItem)
            {
                ItemCell cell = _interactionService.ObservedItemCell;
                _itemDescription.text = $"{cell.ItemName} ({cell.Count}) - Pickup (E)";
            }
        }
    }
}