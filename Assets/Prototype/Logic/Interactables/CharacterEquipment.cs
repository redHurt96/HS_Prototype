using Prototype.Logic.Items;
using UnityEngine;

namespace Prototype.Logic.Interactables
{
    internal class CharacterEquipment : MonoBehaviour
    {
        [SerializeField] private int _force;
        
        public int GetPunchForce(MineItemView mineItemView)
        {
            return _force;
        }
    }
}