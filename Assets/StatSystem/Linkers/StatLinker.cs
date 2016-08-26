using UnityEngine;
using System.Collections;
using System;
namespace Systems.StatSystem
{
    public abstract class StatLinker : IStatValueChanged
    {
        private Stat _stat;

        private bool _secondaryStatLinker;

        public bool SecondaryStatLinker
        {
            get { return _secondaryStatLinker; }
        }

        public event EventHandler OnValueChanged;

        public StatLinker(Stat stat)
        {
            _stat = stat;
            _secondaryStatLinker = false;

            IStatValueChanged iValueChanged = _stat as IStatValueChanged;
            if (iValueChanged != null)
            {
                iValueChanged.OnValueChanged += OnLinkedStatValueChange;
            }
        }

        public StatLinker(Stat stat, bool secondary)
        {
            _stat = stat;
            _secondaryStatLinker = secondary;

            IStatValueChanged iValueChanged = _stat as IStatValueChanged;
            if (iValueChanged != null)
            {
                iValueChanged.OnValueChanged += OnLinkedStatValueChange;
            }
        }

        public Stat StatThatsLinking
        {
            get { return _stat; }
        }

        public abstract int Value { get; }

        private void OnLinkedStatValueChange(object sender, EventArgs args)
        {
            if (OnValueChanged != null)
            {
                OnValueChanged(this, args);
            }
        }

    }
}