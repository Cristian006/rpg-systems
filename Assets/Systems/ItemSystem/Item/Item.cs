using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Systems.StatSystem;
using System;

namespace Systems.ItemSystem
{
    public class Item
    {
        private int _id;
        private string _name;
        private ItemType _iType;
        private string _description;
        private int _weight;
        private bool _stackable;
        private int _stackSize;
        private Sprite _icon;
        private int _level;
        private int _cost;

        #region GETTERS AND SETTERS
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool Stackable
        {
            get { return _stackable; }
            set { _stackable = value; }
        }

        public ItemType IType
        {
            get
            {
                return _iType;
            }

            set
            {
                _iType = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public int Weight
        {
            get
            {
                return _weight;
            }

            set
            {
                _weight = value;
            }
        }

        public int Cost
        {
            get
            {
                return _cost;
            }

            set
            {
                _cost = value;
            }
        }

        public Sprite Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
            }
        }

        public int StackSize
        {
            get
            {
                return _stackSize;
            }

            set
            {
                _stackSize = value;
            }
        }
        #endregion

        #region CONSTRUCTORS
        public Item()
        {

        }

        public Item(ItemAsset ia)
        {
            ID = ia.ID;
            Name = ia.Name;
            IType = ia.IType;
            Weight = ia.Weight;
            Description = ia.Description;
            Stackable = ia.Stackable;
            StackSize = ia.StackSize;
            Icon = ia.Icon;
            Level = ia.Level;
            Cost = ia.Cost;
        }
        #endregion
    }
}