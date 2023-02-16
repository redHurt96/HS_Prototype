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
            Item item = _interactionService.ObservedItem;
            
            _itemDescription.gameObject.SetActive(item != null);
            
            if (item != null) 
                _itemDescription.text = $"{item.Name} ({item.Count}) - Pickup (E)";
        }
    }
}