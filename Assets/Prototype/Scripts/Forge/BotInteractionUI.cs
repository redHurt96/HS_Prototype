using TMPro;
using UnityEngine;

namespace Prototype.Scripts.Forge
{
    public class BotInteractionUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _itemDescription;
        [SerializeField] private BotInteractionService _interactionService;

        private void Update()
        {
            _itemDescription.gameObject.SetActive(_interactionService.IsObserve);

            if (_interactionService.IsObserve) 
                _itemDescription.text = $"Bot - Hunt (E)";
        }
    }
}