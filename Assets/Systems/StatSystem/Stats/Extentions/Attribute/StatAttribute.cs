using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Systems.StatSystem
{
    /*
    Second layer of stat inheritence.

    Added Functionality:
        Stat Linking
    
    Stat Linking so the attribute Courage affects the stat Strength when it changes.
    Use: upgrading attribute values to affect stats
    */
    public class StatAttribute : StatModifiable, IStatScalable, IStatLinkable
    {
        private int _statLevelValue; //level of the attribute
        private int _statLinkerValue; //linked value of the attribute "ratio"
        private List<StatLinker> _statLinkers; //list of linked stats

        #region Constructors
        public StatAttribute() : base ()
        {
            _statLinkers = new List<StatLinker>();
        }
        #endregion

        #region Properties - Getters/Setters
        public override int StatBaseValue
        {
            get { return base.StatBaseValue + StatLevelValue + StatLinkerValue; }
        }

        public int StatLevelValue
        {
            get { return _statLevelValue; }
        }

        public int StatLinkerValue
        {
            get
            {
                return _statLinkerValue;
            }
            set
            {
                _statLinkerValue = value;
            }
        }

        public List<StatLinker> StatLinkers
        {
            get { return _statLinkers; }
        }
        #endregion

        //adding a stat link to the attribute and subscribes to the onValueChangedEvent
        public void AddLinker(StatLinker linker)
        {
            _statLinkers.Add(linker);
            linker.OnValueChanged += OnLinkerValueChanged;
        }

        //clears a stat links and removes the event subscriptions
        public void ClearLinkers()
        {
            foreach (var linker in _statLinkers)
            {
                linker.OnValueChanged -= OnLinkerValueChanged;
            }
            _statLinkers.Clear();
        }

        //scales stat value when attribute is upgraded
        public virtual void ScaleStatToNextLevel()
        {
            ScaleStat(_statLevelValue+1);
        }

        //scales stat when attribute is downgraded
        public virtual void ScaleStatToPrevLevel()
        {
            ScaleStat(_statLevelValue-1);
        }

        //changes attribute to set level
        public virtual void ScaleStat(int level)
        {
            _statLevelValue = level;
            TriggerValueChanged();
        }

        //update the linker value from the list of links
        public virtual void UpdateLinkers()
        {
            _statLinkerValue = 0;
            foreach (StatLinker link in _statLinkers)
            {
                _statLinkerValue += link.Value;
            }
            TriggerValueChanged();
        }
        
        private void OnLinkerValueChanged(object linker, EventArgs args)
        {
            UpdateLinkers();
        }
    }
}