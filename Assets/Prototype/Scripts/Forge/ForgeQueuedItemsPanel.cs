using UnityEngine;

namespace Prototype.Scripts.Forge
{
    internal class ForgeQueuedItemsPanel : MonoBehaviour
    {
        [SerializeField] private ForgeQueuedItemUIView _forgeQueuedItemUIView;
        [SerializeField] private Transform _viewsAnchor;
        
        private Forge _forge;

        public void Setup(Forge forge)
        {
            _forge = forge;
            _forge.ItemsQueueUpdated += PerformUpdate;

            foreach (ForgeCraftProcess process in forge.EnqueuedRecipes)
            {
                ForgeQueuedItemUIView view = Instantiate(_forgeQueuedItemUIView, _viewsAnchor);
                view.Setup(process);
            }
        }

        public void Clear()
        {
            foreach (Transform view in _viewsAnchor) 
                Destroy(view.gameObject);
            
            _forge.ItemsQueueUpdated -= PerformUpdate;
        }

        private void PerformUpdate()
        {
            Clear();
            Setup(_forge);
        }
    }
}