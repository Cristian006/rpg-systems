using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
namespace Systems.StatSystem
{
    public class StatAttribute : StatModifiable, IStatScalable, IStatLinkable
    {
        private int _statLevelValue;
        private int _statLinkerValue;
        private List<StatLinker> _statLinkers;

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

        public void AddLinker(StatLinker linker)
        {
            _statLinkers.Add(linker);
            linker.OnValueChanged += OnLinkerValueChanged;
        }

        public void ClearLinkers()
        {
            foreach (var linker in _statLinkers)
            {
                linker.OnValueChanged -= OnLinkerValueChanged;
            }
            _statLinkers.Clear();
        }

        public virtual void ScaleStatToNextLevel()
        {
            ScaleStat(_statLevelValue+1);
        }

        public virtual void ScaleStatToPrevLevel()
        {
            ScaleStat(_statLevelValue-1);
        }

        public virtual void ScaleStat(int level)
        {
            _statLevelValue = level;
            TriggerValueChanged();
        }

        public virtual void UpdateLinkers()
        {
            _statLinkerValue = 0;
            foreach (StatLinker link in _statLinkers)
            {
                _statLinkerValue += link.Value;
            }
            TriggerValueChanged();
        }

        public StatAttribute()
        {
            _statLinkers = new List<StatLinker>();
        }

        private void OnLinkerValueChanged(object linker, EventArgs args)
        {
            UpdateLinkers();
        }
    }
}