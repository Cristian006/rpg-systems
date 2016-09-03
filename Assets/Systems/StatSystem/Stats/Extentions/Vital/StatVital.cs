using UnityEngine;
using System;
using System.Collections;
namespace Systems.StatSystem
{
    public class StatVital : StatAttribute, IStatCurrentValueChanged
    {
        private int _statCurrentValue;
        public event EventHandler OnCurrentValueChanged;
        
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

        public StatVital()
        {
            _statCurrentValue = 0;
        }

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