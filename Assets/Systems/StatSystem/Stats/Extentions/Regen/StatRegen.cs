using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Systems.StatSystem
{
    public class StatRegen : StatVital, IStatRegen
    {
        private int _baseSecondsPerPoint;
        private int _secondsPerPoint;
        private float _timeForNextRegen = 0;
        private int _min_secondsPerPoint = 1;
        private float _linkMultiplier = 1.2f;
        //TODO: LINKER VARIABLES TO REGEN

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


        public StatRegen()
        {
            TimeForNextRegen = 0;
        }

        public void Regenerate()
        {
            StatCurrentValue++;
            //bug.Log("REGENERATING " + StatName + ": " + StatCurrentValue);
        }

        public override void UpdateLinkers()
        {
            StatLinkerValue = 0;

            foreach (StatLinker link in StatLinkers)
            {
                if (link.SecondaryStatLinker)
                {
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