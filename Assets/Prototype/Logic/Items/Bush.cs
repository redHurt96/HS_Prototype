using System.Collections;
using Prototype.Logic.InventoryBehavior;
using UnityEngine;

namespace Prototype.Logic.Items
{
    public class Bush : MonoBehaviour
    {
        public string Name => _name;
        
        [SerializeField] private string _name;
        [SerializeField] private ItemCell _itemCell;
        [SerializeField] private float _restoreTime;
        [SerializeField] private GameObject _viewToHide;
        [SerializeField] private Collider _collider;

        public void Pickup(Inventory inventory)
        {
            inventory.Add(_itemCell);
            inventory.InvokeUpdate();
            
            _viewToHide.SetActive(false);
            _collider.enabled = false;

            StartCoroutine(Restore());
        }

        private IEnumerator Restore()
        {
            yield return new WaitForSeconds(_restoreTime);
            
            _viewToHide.SetActive(true);
            _collider.enabled = true;
        }
    }
}