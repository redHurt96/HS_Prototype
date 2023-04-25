using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Prototype_v2.Logic.Melee
{
    [CreateAssetMenu(menuName = "Create MeleeConfig", fileName = "MeleeConfig", order = 0)]
    public class MeleeConfig : ScriptableObject
    {
        public AttackConfig First => _attacks.First();
        
        [SerializeField] private List<AttackConfig> _attacks;

        public AttackConfig Next(AttackConfig forAttack) => 
            _attacks.Find(x => x.Order == forAttack.Order + 1);
    }
}