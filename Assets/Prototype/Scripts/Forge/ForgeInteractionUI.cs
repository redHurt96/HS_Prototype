using TMPro;
using UnityEngine;

namespace Prototype.Scripts.Forge
{
    public class ForgeInteractionUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _itemDescription;
        [SerializeField] private ForgeInteractionService _interactionService;
        [SerializeField] private BotHuntingBehavior _botHuntingBehavior;

        private void Update()
        {
            _itemDescription.gameObject.SetActive(_interactionService.IsObserve);

            if (_interactionService.IsObserve)
            {
                _itemDescription.text = $"Forge - Interact (E)";

                ForgeBotPlace botPlace = _interactionService.ObservedForge.GetComponent<ForgeBotPlace>();

                if (botPlace.IsEmpty && _botHuntingBehavior.HasAny)
                    _itemDescription.text += "\n Assign bot (G)";
            }
        }
    }
}