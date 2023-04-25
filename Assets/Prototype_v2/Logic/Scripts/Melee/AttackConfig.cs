using System;

namespace Prototype_v2.Logic.Melee
{
    [Serializable]
    public class AttackConfig
    {
        public int Order;
        public bool HasNext;
        public float Damage;
        public float DamageDelay;
        public float NextComboAttackDelay;
        public float BreakComboDelay;

        public static AttackConfig Empty() =>
            new()
            {
                Order = -1,
                NextComboAttackDelay = 0f,
            };
    }
}