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
                if (GetStat<StatVital>(StatType.Armor).Value > 0)
                {
                    int amountToTakeFromArmor = (int)(amount * (0.01f * GetStat<StatAttribute>(StatType.ArmorProtection).Value));
                    int amountToTakeFromHealth = (amount - amountToTakeFromArmor);
                    int amountLeft = 0;

                    if (GetStat<StatVital>(StatType.Armor).Value >= amountToTakeFromArmor)
                    {
                        GetStat<StatVital>(StatType.Armor).Value -= amountToTakeFromArmor;
                    }
                    else
                    {
                        amountLeft = amountToTakeFromArmor - GetStat<StatVital>(StatType.Armor).Value;
                        GetStat<StatVital>(StatType.Armor).Value = 0;
                    }

                    GetStat<StatVital>(StatType.Health).Value -= (amountToTakeFromHealth + amountLeft);
                }
            }
        }

        public void RestoreHealth(int amount)
        {
            GetStat<StatRegeneratable>(StatType.Health).Value += amount;
        }

        public void RestoreHealth()
        {
            GetStat<StatRegeneratable>(StatType.Health).RestoreCurrentValueToMax();
        }
    }
}
