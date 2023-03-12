using Prototype.Logic.Forge;
using TMPro;
using UnityEngine;

namespace Prototype.Logic.Characters.UI
{
    public class BotIsMineUIView : MonoBehaviour
    {
        [SerializeField] private Bot _bot;
        [SerializeField] private TextMeshProUGUI _name;

        private void Awake()
        {
            _bot.OnHunted += Enable;
        }

        private void Enable()
        {
            _bot.OnHunted -= Enable;

            _name.enabled = true;
        }
    }
}