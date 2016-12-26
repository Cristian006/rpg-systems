using UnityEngine;
using System.Collections;
using System;
namespace Systems.StatSystem
{
    //example mod
    //this adds the total modValue back to the stat value 
    public class StatModTotalAdd : StatModifier
    {
        #region Constructors
        public StatModTotalAdd() : base() { }

        public StatModTotalAdd(float value) : base(value) { }

        public StatModTotalAdd(float value, bool stacks) : base(value, stacks) { }
        #endregion

        //this mod order
        public override int Order
        {
            get
            {
                return 4;
            }
        }

        //this adds the total modValue back to the stat value
        //since this is 4th in line it will get the total after previous mods have been added
        public override int ApplyModifier(int statValue, float modValue)
        {
            return (int)(modValue);
        }
    }
}