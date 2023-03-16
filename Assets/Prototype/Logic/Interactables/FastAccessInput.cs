using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Logic.Interactables
{
    internal class FastAccessInput : MonoBehaviour
    {
        [SerializeField] private FastAccessBehavior _fastAccess;

        private readonly Dictionary<KeyCode, int> _codes = new()
        {
            [KeyCode.Alpha1] = 0,
            [KeyCode.Alpha2] = 1,
            [KeyCode.Alpha3] = 2,
            [KeyCode.Alpha4] = 3,
            [KeyCode.Alpha5] = 4,
            [KeyCode.Alpha6] = 5,
            [KeyCode.Alpha7] = 6,
            [KeyCode.Alpha8] = 7,
            [KeyCode.Alpha9] = 8,
            [KeyCode.Alpha0] = 9,
        };

        private void Update()
        {
            foreach (KeyValuePair<KeyCode,int> pair in _codes)
            {
                if (Input.GetKeyDown(pair.Key) && _fastAccess.HasItemAt(pair.Value)) 
                    _fastAccess.Use(pair.Value);
            }
        }
    }
}