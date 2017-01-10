using UnityEngine;
using System.Collections;
using System;
namespace Systems.StatSystem
{
    //this is an abstract class which is used with stat attribute to create stat links between attributes and stats
    public abstract class StatLinker : IStatValueChanged
    {
        //the stat that the attribute is linked to
        private Stat _stat;

        //adding functionality to be able to effect a secondary stat on the same stat (confusing ikr)
        //ex: Stat regen - you can link to it and effect the base stat value or link to it as a secondary stat linker and effect the regen amount
        private bool _secondaryStatLinker;

        public event EventHandler OnValueChanged;

        #region Constructor
        public StatLinker()
        {
            _stat = null;
            _secondaryStatLinker = false;
        }

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
        #endregion

        #region Properties - Getters/Setters
        public bool SecondaryStatLinker
        {
            get { return _secondaryStatLinker; }
        }

        public Stat StatThatsLinking
        {
            get { return _stat; }
        }

        public abstract int Value { get; }
        #endregion

        private void OnLinkedStatValueChange(object sender, EventArgs args)
        {
            if (OnValueChanged != null)
            {
                OnValueChanged(this, args);
            }
        }

    }
}