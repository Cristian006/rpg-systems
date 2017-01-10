using UnityEngine;
using System.Collections;
using Systems.ItemSystem.Interfaces;

namespace Systems.ItemSystem
{
    public class Weapon : Item, IDestructible, IEquipable
    {
        private int _durability;
        private int _currentDurablity;
        private bool _equipable;
        private WeaponType _weaponType;

        #region GETTERS AND SETTERS
        public int CurrentDurability
        {
            get
            {
                return _currentDurablity;
            }
            set
            {
                _currentDurablity = value;
                if (_currentDurablity <= 0)
                {
                    _currentDurablity = 0;
                    Break();
                }
            }
        }

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

        public bool Equipable
        {
            get
            {
                return _equipable;
            }
        }

        public WeaponType WeaponType
        {
            get
            {
                return _weaponType;
            }

            set
            {
                _weaponType = value;
            }
        }
        #endregion

        public Weapon(WeaponAsset wa) : base((ItemAsset)wa)
        {
            this.Durability = wa.Durability;
            this.WeaponType = wa.WType;
        }

        public void Break()
        {
            _equipable = false;
        }

        public void Repair()
        {
            _equipable = true;
            CurrentDurability = Durability;
        }

        public void TakeDamage(int amount)
        {
            CurrentDurability -= amount;
        }
    }
}