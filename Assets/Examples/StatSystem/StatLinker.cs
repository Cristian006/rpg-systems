using UnityEngine;
using System.Collections;
using Systems.StatSystem;

namespace Systems.Example
{
    //example Linker
    //Basic StatLinker
    public class StatLinker : StatSystem.StatLinker
    {
        private float _ratio;

        #region Constructors
        public StatLinker() : base()
        {
            //empty constructor
            _ratio = 0;
        }
        public StatLinker(Stat stat, float ratio) : base(stat)
        {
            _ratio = ratio;
        }

        public StatLinker(Stat stat, float ratio, bool secondary) : base(stat, secondary)
        {
            _ratio = ratio;
        }
        #endregion

        public float Ratio
        {
            get { return _ratio; }
        }

        public override int Value
        {
            get
            {
                //The attributes value * the given ratio which is later added to the linked stat's base value
                return (int)(StatThatsLinking.Value * _ratio);
            }
        }


    }
}