using TMPro;
using UnityEngine;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
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
                Item item = _interactionService.ObservedItem;
                _itemDescription.text = $"{item.Name} ({item.Count}) - Pickup (E)";
            }
        }
    }
}