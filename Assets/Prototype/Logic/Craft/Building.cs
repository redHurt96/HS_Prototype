using Prototype.Logic.Attributes;
using UnityEngine;

namespace Prototype.Logic.Craft
{
    public class Building : MonoBehaviour
    {
        public string Name;
        [ReadOnly] public string UniqueKey;
    }
}