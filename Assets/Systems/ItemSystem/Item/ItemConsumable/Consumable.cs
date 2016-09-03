using UnityEngine;
using System.Collections;
using Systems.StatSystem;

namespace Systems.ItemSystem
{
    public class Consumable : Item 
    {
        private StatType statToEffect;
        public StatType StatToEffect
        {
            get { return statToEffect; }
            set { statToEffect = value; }
        }
    }
}