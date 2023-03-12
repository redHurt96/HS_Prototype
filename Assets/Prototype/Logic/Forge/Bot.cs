using System;
using Prototype.Logic.Attributes;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class Bot : MonoBehaviour
    {
        public event Action OnHunted;
        
        public string Name;
        public bool IsAssignedToVillage => Village != null;
        public Village Village => _village;

        [ReadOnly] public string BuildingKey;
        
        [SerializeField, ReadOnly] private Village _village;

        public void AssignVillage(Village village)
        {
            _village = village;
            
            OnHunted?.Invoke();
        }
    }
}