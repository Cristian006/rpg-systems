using UnityEngine;
using System.Collections;
namespace Systems.StatSystem
{
    //example mod
    //add Mod value to the base value of the stat
    public class StatModBaseAdd : StatModifier
    {
        #region Constructors
        public StatModBaseAdd() : base() { }

        public StatModBaseAdd(float value) : base(value) { }

        public StatModBaseAdd(float value, bool stacks) : base(value, stacks) { }
        #endregion

        //this mod order
        public override int Order
        {
            get
            {
                return 2;
            }
        }

        //this mod just returns the modValue which will later be added
        public override int ApplyModifier(int statValue, float modValue)
        {
            return (int)(modValue);
        }

    }
}