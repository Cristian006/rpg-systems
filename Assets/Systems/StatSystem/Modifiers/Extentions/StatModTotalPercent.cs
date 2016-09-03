using UnityEngine;
using System.Collections;
namespace Systems.StatSystem
{
    public class StatModTotalPercent : StatModifier
    {
        public override int Order
        {
            get
            {
                return 3;
            }
        }

        public override int ApplyModifier(int statValue, float modValue)
        {
            return (int)(statValue * modValue);
        }

        public StatModTotalPercent(float value) : base(value) { }

        public StatModTotalPercent(float value, bool stacks) : base(value, stacks) { }
    }
}