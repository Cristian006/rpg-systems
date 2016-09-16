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

        #region GETTERS AND SETTERS
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
        #endregion

        public WeaponAsset() : base (){
            this.Durability = 0;
            this.Equipable = true;
            this.IType = ItemType.Weapon;
            this.WType = WeaponType.None;
            this.AttackRange = 0;
            this.WeaponDamage = 0;
        }

        public WeaponAsset(int id) : base (id)
        {
            this.Durability = 0;
            this.Equipable = true;
            this.IType = ItemType.Weapon;
            this.WType = WeaponType.None;
            this.AttackRange = 0;
            this.WeaponDamage = 0;
        }


        public WeaponAsset(int id, string name) : base (id, name)
        {
            this.Durability = 0;
            this.Equipable = true;
            this.IType = ItemType.Weapon;
            this.WType = WeaponType.None;
            this.AttackRange = 0;
            this.WeaponDamage = 0;
        }

        public WeaponAsset(int id, string name, int weight, string description, bool stackable, int stackSize, Sprite icon, int level, int cost) : base(id, name, weight, description, stackable, stackSize, icon, level, cost)
        {
            this.Durability = 0;
            this.Equipable = true;
            this.IType = ItemType.Weapon;
            this.WType = WeaponType.None;
            this.AttackRange = 0;
            this.WeaponDamage = 0;
        }

        public WeaponAsset(int id, string name, int weight, string description, bool stackable, int stackSize, Sprite icon, int level, int cost, int durability, bool equipable, WeaponType wType, int attackRange, int weaponDamage) : base(id, name, weight, description, stackable, stackSize, icon, level, cost)
        {
            this.Durability = durability;
            this.Equipable = equipable;
            this.IType = ItemType.Weapon;
            this.WType = wType;
            this.AttackRange = attackRange;
            this.WeaponDamage = weaponDamage;
        }
    }
}