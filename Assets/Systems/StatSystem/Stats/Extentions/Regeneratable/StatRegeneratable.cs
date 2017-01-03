using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Systems.StatSystem
{
    /*
    Fourth layer of stat inheritence.

    Added Functionality:
        Regeneration of stat points to the current value of the stat
    
    Stat Regen is a regenerating Stat
    Downside: makes Stat Collection have to be a Monobehaviour to work with the update function
        (not really a downside - haven't run into any issues yet)
        Ex: Health
            - has current stat value: 45 HP
            - has max stat value: 100 HP
            - regen amount per second .5 pt
                (every two seconds the stat will regenerate a single stat point)
    */
    public class StatRegeneratable : StatVital, IStatRegeneratable
    {
        private int _baseSecondsPerPoint;
        private int _secondsPerPoint;
        private float _timeForNextRegen = 0;
        private int _min_secondsPerPoint = 1;
        private float _linkMultiplier = 1.2f;
        //TODO: LINKER VARIABLES TO REGEN AMOUNT so when linked it can change not the stat value but the secondary stat - seconds per point which I started implementing in Stat Linker class but haven't finished

        #region Constructors
        public StatRegeneratable()
        {
            TimeForNextRegen = 0;
        }
        #endregion

        #region Properties - Getters/Setters
        /// <summary>
        /// The amount of time required to regen 1 point
        /// </summary>
        public int SecondsPerPoint
        {
            get
            {
                return _secondsPerPoint;
            }
            set
            {
                if (value < MinSecondsPerPoint)
                {
                    value = MinSecondsPerPoint;
                }
                _timeForNextRegen = 0;
                _secondsPerPoint = value;
            }
        }

        public int BaseSecondsPerPoint
        {
            get
            {
                return _baseSecondsPerPoint;
            }
            set
            {
                _baseSecondsPerPoint = value;
                _secondsPerPoint = _baseSecondsPerPoint;
            }
        }

        public float LinkMultiplier
        {
            get
            {
                return _linkMultiplier;
            }
        }

        public int MinSecondsPerPoint
        {
            get
            {
                return _min_secondsPerPoint;
            }
        }

        /// <summary>
        /// Regen Amount Per Second
        /// </summary>
        public float RegenAmount
        {
            get
            {
                if (SecondsPerPoint <= 0)
                {
                    SecondsPerPoint = 0;
                    return 0;
                }
                else
                {
                    return (float)(1f / (float)SecondsPerPoint);
                }
            }
        }

        public float TimeForNextRegen
        {
            get
            {
                return _timeForNextRegen;
            }

            set
            {
                _timeForNextRegen = value;
            }
        }
        #endregion

        //regenerate the point
        public void Regenerate()
        {
            StatCurrentValue++;
            //bug.Log("REGENERATING " + StatName + ": " + StatCurrentValue);
        }

        //overriding the update linker function to work with the secondary stat linkers
        public override void UpdateLinkers()
        {
            StatLinkerValue = 0;

            foreach (StatLinker link in StatLinkers)
            {
                if (link.SecondaryStatLinker)
                {
                    //secondaryStatLinks effecting the regen amount per seconds
                    SecondsPerPoint = BaseSecondsPerPoint - (int)(link.Value * LinkMultiplier);
                }
                else
                {
                    StatLinkerValue += link.Value;
                }
            }

            TriggerValueChanged();
        }
    }
}