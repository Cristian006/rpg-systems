using UnityEngine;
using System.Collections;
using System;

namespace Systems.StatSystem
{
    //example Linker
    //Basic StatLinker
    public class ExampleStatLinker : StatLinker
    {
        private float _ratio;

        #region Constructors
        public ExampleStatLinker() : base()
        {
            //empty constructor
            _ratio = 0;
        }
        public ExampleStatLinker(Stat stat, float ratio) : base(stat)
        {
            _ratio = ratio;
        }

        public ExampleStatLinker(Stat stat, float ratio, bool secondary) : base(stat, secondary)
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
                return (int)(StatThatsLinking.StatValue * _ratio);
            }
        }


    }
}