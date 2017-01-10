using UnityEngine;
using System;
using System.Collections;
namespace Systems.StatSystem
{
    /*
    Third layer of stat inheritence.

    Added Functionality:
        Current and Max Stat Value
    
    Stat Vital is a complete Stat
        Ex: Health
            - has current stat value: 45 HP
            - has max stat value: 100 HP
    */
    public class StatVital : StatAttribute, IStatCurrentValueChanged
    {
        private int _value; //the stats current value

        public event EventHandler OnCurrentValueChanged; //event for when the stat value changes  

        #region Constructors 
        public StatVital()
        {
            _value = 0;
        }
        #endregion

        #region Properties - Getters/Setters
        new public int Value
        {
            get
            {
                if (_value > base.Value)
                {
                    _value = base.Value;
                }
                else if (_value < 0)
                {
                    _value = 0;
                }
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    TriggerCurrentValueChange();
                }
            }
        }

        public int Max
        {
            get { return base.Value; }
            set { base.Base = value; }
        }
        #endregion

        public void RestoreCurrentValueToMax()
        {
            Value = base.Value;
        }

        private void TriggerCurrentValueChange()
        {
            if (OnCurrentValueChanged != null)
            {
                OnCurrentValueChanged(this, null);
            }
        }
    }
}