using Prototype.Logic.Items;
using UnityEngine;
using static Prototype.Logic.Interactables.ResourcesService;

namespace Prototype.Logic.Interactables
{
    internal class FastAccessUIView : MonoBehaviour
    {
        [SerializeField] private FastAccessBehavior _fastAccess;
        [Space] 
        [SerializeField] private FastAccessItemUIView[] _images;

        private void Start()
        {
            _fastAccess.Updated += UpdateView;

            UpdateView();
        }

        private void OnDestroy() => 
            _fastAccess.Updated -= UpdateView;

        private void UpdateView()
        {
            for (int i = 0; i < _fastAccess.Items.Count; i++)
            {
                ItemCell itemCell = _fastAccess.Items[i];
                
                if (itemCell.IsEmpty)
                {
                    _images[i].Clear();    
                    continue;
                }

                _images[i].Setup(i, GetItemIcon(itemCell.ItemName));
            }
        }
    }
}