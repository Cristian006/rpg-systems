using UnityEngine;
using System.Collections;

namespace Systems.ItemSystem
{
    [System.Serializable]
    public class WeaponAsset : ItemAsset
    {
        [SerializeField]
        private int _durability;
        [SerializeField]
        private bool _equipable;
        [SerializeField]
        private WeaponType _wType;
        [SerializeField]
        private int _attackRange;
        [SerializeField]
        private int _weaponDamage;

        private int _currentDurablity;

        public int Durability
        {
            get
            {
                return _durability;
            }

            set
            {
                _durability = value;
            }
        }

        public int CurrentDurablity
        {
            get
            {
                return _currentDurablity;
            }

            set
            {
                _currentDurablity = value;
            }
        }

        public bool Equipable
        {
            get
            {
                return _equipable;
            }

            set
            {
                _equipable = value;
            }
        }

        public WeaponType WType
        {
            get
            {
                return _wType;
            }

            set
            {
                _wType = value;
            }
        }

        public int AttackRange
        {
            get
            {
                return _attackRange;
            }

            set
            {
                _attackRange = value;
            }
        }

        public int WeaponDamage
        {
            get
            {
                return _weaponDamage;
            }

            set
            {
                _weaponDamage = value;
            }
        }

        public WeaponAsset() : base (){
            this.Durability = 0;
            this.Equipable = true;
            this.IType = ItemType.Weapon;
            this.WType = WeaponType.None;
        }

        public WeaponAsset(int id) : base (id)
        {
            this.Durability = 0;
            this.Equipable = true;
            this.IType = ItemType.Weapon;
            this.WType = WeaponType.None;
        }


        public WeaponAsset(int id, string name) : base (id, name)
        {
            this.Durability = 0;
            this.Equipable = true;
            this.IType = ItemType.Weapon;
            this.WType = WeaponType.None;
        }

        public WeaponAsset(int id, string name, ItemType iType, int weight, string description, bool stackable) : base(id, name, iType, weight, description, stackable)
        {
            this.Durability = 0;
            this.Equipable = true;
            this.IType = ItemType.Weapon;
            this.WType = WeaponType.None;
        }

        public WeaponAsset(int id, string name, ItemType iType, int weight, string description, bool stackable, int durability, bool equipable, WeaponType wType) : base(id, name, iType, weight, description, stackable)
        {
            this.Durability = durability;
            this.Equipable = equipable;
            this.IType = ItemType.Weapon;
            this.WType = wType;
        }
    }
}