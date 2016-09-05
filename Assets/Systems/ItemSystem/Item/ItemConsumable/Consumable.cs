using UnityEngine;
using System.Collections;
using Systems.StatSystem;

namespace Systems.ItemSystem
{
    public class Consumable : Item 
    {
        private StatType statToEffect;
        private int effectAmount;

        public StatType StatToEffect
        {
            get { return statToEffect; }
            set { statToEffect = value; }
        }

        public int EffectAmount
        {
            get { return effectAmount; }
            set { effectAmount = value; }
        }

        public Consumable(ConsumableAsset ca) : base((ItemAsset)ca)
        {
            StatToEffect = ca.StatToEffect;
            EffectAmount = ca.EffectAmount;
        }
    }
}