using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.StatSystem;


namespace Systems.Example
{
    public class Entity : EntitySystem.Entity
    {
        protected override void Awake()
        {
            //Nothing to initialize for this
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public virtual void TakeDamage(int amount)
        {
            {
                if (GetStat<StatVital>(StatType.Armor).StatCurrentValue > 0)
                {
                    int amountToTakeFromArmor = (int)(amount * (0.01f * GetStat<StatAttribute>(StatType.ArmorProtection).StatValue));
                    int amountToTakeFromHealth = (amount - amountToTakeFromArmor);
                    int amountLeft = 0;

                    if (GetStat<StatVital>(StatType.Armor).StatCurrentValue >= amountToTakeFromArmor)
                    {
                        GetStat<StatVital>(StatType.Armor).StatCurrentValue -= amountToTakeFromArmor;
                    }
                    else
                    {
                        amountLeft = amountToTakeFromArmor - GetStat<StatVital>(StatType.Armor).StatCurrentValue;
                        GetStat<StatVital>(StatType.Armor).StatCurrentValue = 0;
                    }

                    GetStat<StatVital>(StatType.Health).StatCurrentValue -= (amountToTakeFromHealth + amountLeft);
                }
            }
        }

        public void RestoreHealth(int amount)
        {
            GetStat<StatRegeneratable>(StatType.Health).StatCurrentValue += amount;
        }

        public void RestoreHealth()
        {
            GetStat<StatRegeneratable>(StatType.Health).RestoreCurrentValueToMax();
        }
    }
}
