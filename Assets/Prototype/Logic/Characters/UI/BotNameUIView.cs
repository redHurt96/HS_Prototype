using Prototype.Logic.Forge;
using TMPro;
using UnityEngine;

namespace Prototype.Logic.Characters.UI
{
    public class BotNameUIView : MonoBehaviour
    {
        [SerializeField] private Bot _bot;
        [SerializeField] private TextMeshProUGUI _name;

        private void Start() => 
            _name.text = _bot.Name;
    }
}