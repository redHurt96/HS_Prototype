using System.Collections;
using Prototype.Logic.Items;
using UnityEngine;
using static Prototype.Logic.Items.ItemsStorage;
using static UnityEngine.Application;

namespace Prototype.Logic.InventoryBehavior
{
    public class InventoryFoodExpirationTimer : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;

        private IEnumerator Start()
        {
            while (isPlaying)
            {
                yield return new WaitForSeconds(1f);

                for (int i = 0; i < _inventory.Cells.Count; i++)
                {
                    Item item = Get(_inventory.Cells[i].ItemName);
                    
                    if (!item.IsFood)
                        continue;

                    _inventory.UpdateTime(i, _inventory.Cells[i].ExpirationTime - 1);

                    if (_inventory.Cells[i].ExpirationTime <= 0)
                    {
                        _inventory.RemoveAt(i);
                        _inventory.InvokeUpdate();
                    }
                }
            }
        }
    }
}