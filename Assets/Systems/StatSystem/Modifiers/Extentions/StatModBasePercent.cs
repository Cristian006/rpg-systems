using UnityEngine;
using System.Collections;
using System;
namespace Systems.StatSystem
{
    //example mod
    //this mod value takes the base stat value and takes a percentage of it to add back onto the stat value
    public class StatModBasePercent : StatModifier
    {
        #region Constructors
        public StatModBasePercent() : base() { }

        public StatModBasePercent(float value) : base(value) { }

        public StatModBasePercent(float value, bool stacks) : base(value, stacks) { }
        #endregion

        //this mod order
        public override int Order
        {
            get
            {
                return 1;
            }
        }

        //this mod value takes the base stat value and takes a percentage of it to add back onto the stat value
        public override int ApplyModifier(int statValue, float modValue)
        {
            return (int)(statValue * modValue);
        }        
    }
}