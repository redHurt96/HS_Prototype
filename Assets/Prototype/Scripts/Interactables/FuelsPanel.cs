using Prototype.Scripts.Craft;
using Prototype.Scripts.InventoryBehavior;
using UnityEngine;

namespace Prototype.Scripts.Interactables
{
    internal class FuelsPanel : MonoBehaviour
    {
        [SerializeField] private FuelUIView _fuelUIView;
        [SerializeField] private Transform _viewsAnchor;
        
        private Forge _forge;

        public void Setup(Forge forge)
        {
            _forge = forge;
            
            foreach (Fuel fuel in forge.FuelQueue)
            {
                FuelUIView view = Instantiate(_fuelUIView, _viewsAnchor);
                view.Setup(fuel);
            }

            _forge.FuelUpdated += PerformUpdate;
        }

        public void Clear()
        {
            foreach (Transform child in _viewsAnchor) 
                Destroy(child.gameObject);
            
            _forge.FuelUpdated -= PerformUpdate;
        }

        private void PerformUpdate()
        {
            Clear();
            Setup(_forge);
        }
    }
}