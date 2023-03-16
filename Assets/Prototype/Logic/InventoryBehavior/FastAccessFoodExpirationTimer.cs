using System.Collections;
using Prototype.Logic.Interactables;
using Prototype.Logic.Items;
using UnityEngine;
using static Prototype.Logic.Items.ItemsStorage;

namespace Prototype.Logic.InventoryBehavior
{
    public class FastAccessFoodExpirationTimer : MonoBehaviour
    {
        [SerializeField] private FastAccessBehavior _fastAccess;

        private IEnumerator Start()
        {
            while (Application.isPlaying)
            {
                yield return new WaitForSeconds(1f);

                for (int i = 0; i < _fastAccess.Items.Count; i++)
                {
                    if (_fastAccess.Items[i].IsEmpty)
                        continue;
                    
                    Item item = Get(_fastAccess.Items[i].ItemName);
                    
                    if (!item.IsFood)
                        continue;

                    _fastAccess.UpdateTime(i, _fastAccess.Items[i].ExpirationTime - 1);

                    if (_fastAccess.Items[i].ExpirationTime <= 0) 
                        _fastAccess.Clear(i);
                }
            }
        }
    }
}