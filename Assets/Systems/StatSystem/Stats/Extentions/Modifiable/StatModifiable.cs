using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Systems.StatSystem
{
    /*
    First layer of stat inheritence.

    Added Functionality:
        Stat Mods
    
    Stat Modifications that can effect the stat value by adding a stat modifiers onto it
    Use: temporary stat effects
    */
    public class StatModifiable : Stat, IStatModifiable, IStatValueChanged
    {
        private List<StatModifier> _statMods; // the added list of stat modifictaions on this stat
        public event EventHandler OnValueChanged; // event for when a mod is added or removed
        private int _statModValue; // the modified value of the stat

        #region Constructors
        public StatModifiable()
        {
            //empty constructor
            _statModValue = 0;
            _statMods = new List<StatModifier>();
        }
        #endregion

        #region Properties - Getters/Setters
        //the stats new value is the total modValue added to the stats base value
        public override int StatValue
        {
            get
            {
                return base.StatValue + StatModifierValue;
            }
        }

        //the stats current mod value of added modifiers
        public int StatModifierValue
        {
            get
            {
                return _statModValue;
            }
        }
        #endregion

        //adding a modifier calls the OnValueChanged Event
        public void AddModifier(StatModifier mod)
        {
            _statMods.Add(mod);
        }

        //removing a modifier calls the OnValueChanged Event
        public void RemoveModifier(StatModifier mod)
        {
            _statMods.Remove(mod);
            mod.OnValueChange -= OnModValueChanged;
        }

        //clears all modifiers off the stat - deleting the list
        public void ClearModifiers()
        {
            foreach (var mod in _statMods)
            {
                mod.OnValueChange -= OnModValueChanged;
            }
            _statMods.Clear();
        }

        //when a new modifier is added, update the modifiers on the stat
        public void UpdateModifiers()
        {
            _statModValue = 0;

            //getting the modifiers in the correct order of effect
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

                //getting the effected mod value and adding it to the total modified value of the stat
                _statModValue += group.First().ApplyModifier(StatBaseValue + _statModValue, (sum > max) ? sum : max);
            }

            //Trigger the event that this stats overall value changed
            TriggerValueChanged();
        }

        //triggered when the total mod value changes
        protected void TriggerValueChanged()
        {
            if (OnValueChanged != null)
            {
                OnValueChanged(this, null);
            }
        }

        //called when a mod is removed or added
        public void OnModValueChanged(object mod, EventArgs args)
        {
            UpdateModifiers();
        }
    }
}