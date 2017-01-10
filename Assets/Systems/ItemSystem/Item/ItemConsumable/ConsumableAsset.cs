using UnityEngine;
using Systems.StatSystem;

namespace Systems.ItemSystem
{
    [System.Serializable]
    public class ConsumableAsset : ItemAsset
    {
        [SerializeField]
        private StatType statToEffect;
        [SerializeField]
        private int _effectAmount;

        public int EffectAmount
        {
            get { return _effectAmount; }
            set { _effectAmount = value; }
        }

        public StatType StatToEffect
        {
            get { return statToEffect; }
            set { statToEffect = value; }
        }

        public ConsumableAsset() : base (){
            this.IType = ItemType.Consumable;
            this.StatToEffect = StatType.None;
            this.EffectAmount = 0;
        }

        public ConsumableAsset(int id) : base (id)
        {
            this.IType = ItemType.Consumable;
            this.StatToEffect = StatType.None;
            this.EffectAmount = 0;
        }


        public ConsumableAsset(int id, string name) : base (id, name)
        {
            this.IType = ItemType.Consumable;
            this.StatToEffect = StatType.None;
            this.EffectAmount = 0;
        }

        public ConsumableAsset(int id, string name, int weight, string description, bool stackable, int stackSize, Sprite icon, int level, int cost) : base(id, name, weight, description, stackable, stackSize, icon, level, cost)
        {
            this.IType = ItemType.Consumable;
            this.StatToEffect = StatType.None;
            this.EffectAmount = 0;
        }

        public ConsumableAsset(int id, string name, int weight, string description, bool stackable, int stackSize, Sprite icon, int level, int cost, StatType statToEffect, int effectAmount) : base(id, name, weight, description, stackable, stackSize, icon, level, cost)
        {
            this.IType = ItemType.Consumable;
            this.StatToEffect = statToEffect;
            this.EffectAmount = effectAmount;
        }
    }
}
