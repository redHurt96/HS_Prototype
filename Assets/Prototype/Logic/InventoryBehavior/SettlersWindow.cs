using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Craft;
using Prototype.Logic.Forge;
using Prototype.Logic.Framework.UI;
using UnityEngine;

namespace Prototype.Logic.InventoryBehavior
{
    public class SettlersWindow : Window
    {
        [SerializeField] private Village _village;
        
        [Space]
        [SerializeField] private SettlerUIView _settlerUIView;
        [SerializeField] private Transform _anchor;

        private readonly List<SettlerUIView> _views = new();
        
        private void OnEnable() => 
            Setup();

        private void OnDisable() => 
            Clear();

        private void Setup()
        {
            foreach (Bot bot in _village.Bots)
            {
                SettlerUIView view = Instantiate(_settlerUIView, _anchor);
                
                if (!string.IsNullOrEmpty(bot.BuildingKey))
                {
                    Building building = _village.Buildings
                        .First(x => x.UniqueKey == bot.BuildingKey);
                    
                    view.Setup(bot, building);
                }
                else
                {
                    view.Setup(bot);
                }
                
                _views.Add(view);
            }
        }

        private void Clear()
        {
            foreach (SettlerUIView view in _views) 
                Destroy(view.gameObject);
            
            _views.Clear();
        }
    }
}