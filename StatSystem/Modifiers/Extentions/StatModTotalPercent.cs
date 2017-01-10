using UnityEngine;
using System.Collections;
namespace Systems.StatSystem
{
    //example mod
    //this takes the total statValue and takes the modValue percentage to add back to the stat value
    public class StatModTotalPercent : StatModifier
    {
        #region Constructors
        public StatModTotalPercent() : base() { }

        public StatModTotalPercent(float value) : base(value) { }

        public StatModTotalPercent(float value, bool stacks) : base(value, stacks) { }
        #endregion
        
        //this mod order
        public override int Order
        {
            get
            {
                return 3;
            }
        }

        //this takes the total statValue and takes the modValue percentage to add back to the stat value
        public override int ApplyModifier(int statValue, float modValue)
        {
            return (int)(statValue * modValue);
        }
    }
}