using UnityEngine;
using Systems.StatSystem;

namespace Systems.ItemSystem
{
    [System.Serializable]
    public class ConsumableAsset : ItemAsset
    {
        [SerializeField]
        private StatType statToEffect;

        public StatType StatToEffect
        {
            get { return statToEffect; }
            set { statToEffect = value; }
        }

        public ConsumableAsset() : base (){
            this.IType = ItemType.Consumable;
            this.StatToEffect = StatType.None;
        }

        public ConsumableAsset(int id) : base (id)
        {
            this.IType = ItemType.Consumable;
            this.StatToEffect = StatType.None;
        }


        public ConsumableAsset(int id, string name) : base (id, name)
        {
            this.IType = ItemType.Consumable;
            this.StatToEffect = StatType.None;
        }

        public ConsumableAsset(int id, string name, ItemType iType, int weight, string description, bool stackable) : base(id, name, iType, weight, description, stackable)
        {
            this.IType = ItemType.Consumable;
            this.StatToEffect = StatType.None;
        }

        public ConsumableAsset(int id, string name, ItemType iType, int weight, string description, bool stackable, int durability, bool equipable, WeaponType wType) : base(id, name, iType, weight, description, stackable)
        {
            this.IType = ItemType.Consumable;
            this.StatToEffect = StatType.None;
        }
    }
}
