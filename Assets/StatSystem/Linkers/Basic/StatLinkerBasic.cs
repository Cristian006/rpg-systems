using UnityEngine;
using System.Collections;
using System;

namespace Systems.StatSystem
{
    public class StatLinkerBasic : StatLinker
    {
        private float _ratio;

        public float Ratio
        {
            get { return _ratio; }
        }

        public override int Value
        {
            get
            {
                //The attributes value * the given ratio which is later added to the linked stat's base value
                return (int)(StatThatsLinking.StatValue * _ratio);
            }
        }

        public StatLinkerBasic(Stat stat, float ratio) : base(stat)
        {
            _ratio = ratio;
        }

        public StatLinkerBasic(Stat stat, float ratio, bool secondary) : base(stat, secondary)
        {
            _ratio = ratio;
        }
    }
}