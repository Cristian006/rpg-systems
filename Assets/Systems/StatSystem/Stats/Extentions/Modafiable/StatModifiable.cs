using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Systems.StatSystem
{
    public class StatModifiable : Stat, IStatModifiable, IStatValueChanged
    {
        private List<StatModifier> _statMods;
        private int _statModValue;

        public event EventHandler OnValueChanged;

        public override int StatValue
        {
            get
            {
                return base.StatValue + StatModifierValue;
            }
        }

        public int StatModifierValue
        {
            get
            {
                return _statModValue;
            }
        }

        public StatModifiable()
        {
            _statModValue = 0;
            _statMods = new List<StatModifier>();
        }

        public void AddModifier(StatModifier mod)
        {
            _statMods.Add(mod);
        }

        public void RemoveModifier(StatModifier mod)
        {
            _statMods.Remove(mod);
            mod.OnValueChange -= OnModValueChanged;
        }

        public void ClearModifiers()
        {
            foreach (var mod in _statMods)
            {
                mod.OnValueChange -= OnModValueChanged;
            }
            _statMods.Clear();
        }

        public void UpdateModifiers()
        {
            _statModValue = 0;
            var orderGroups = _statMods.OrderBy(m => m.Order).GroupBy(m => m.Order);

            foreach (var group in orderGroups)
            {
                float sum = 0, max = 0;
                foreach (var mod in group)
                {
                    if (mod.Stacks == false)
                    {
                        max = mod.Value;
                    }
                    else
                    {
                        sum += mod.Value;
                    }
                }

                _statModValue += group.First().ApplyModifier(StatBaseValue + _statModValue, (sum > max) ? sum : max);
            }
            TriggerValueChanged();
        }

        protected void TriggerValueChanged()
        {
            if (OnValueChanged != null)
            {
                OnValueChanged(this, null);
            }
        }

        public void OnModValueChanged(object mod, EventArgs args)
        {
            UpdateModifiers();
        }
    }
}