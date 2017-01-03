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
        private int _statCurrentValue; //the stats current value

        public event EventHandler OnCurrentValueChanged; //event for when the stat value changes  

        #region Constructors 
        public StatVital()
        {
            _statCurrentValue = 0;
        }
        #endregion

        #region Properties - Getters/Setters
        public int StatCurrentValue
        {
            get
            {
                if (_statCurrentValue > StatValue)
                {
                    _statCurrentValue = StatValue;
                }
                else if (_statCurrentValue < 0)
                {
                    _statCurrentValue = 0;
                }
                return _statCurrentValue;
            }
            set
            {
                if (_statCurrentValue != value)
                {
                    _statCurrentValue = value;
                    TriggerCurrentValueChange();
                }
            }
        }
        #endregion

        public void RestoreCurrentValueToMax()
        {
            StatCurrentValue = StatValue;
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