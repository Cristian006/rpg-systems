using UnityEngine;
using System;
using System.Collections.Generic;
using Systems.Utility.Database;
using UnityEditor;

namespace Systems.ItemSystem
{
    [Serializable]
    public class ItemAsset : BaseDatabaseAsset
    {
        [SerializeField]
        private ItemType _iType;
        [SerializeField]
        private string _description;
        [SerializeField]
        private int _weight;
        [SerializeField]
        private bool _stackable;
        [SerializeField]
        private int _stackSize;
        [SerializeField]
        private Sprite _icon;
        [SerializeField]
        private int _level;
        [SerializeField]
        private int _cost;

        #region GETTERS AND SETTERS
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

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public int StackSize
        {
            get { return _stackSize; }
            set { _stackSize = value; }
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

        public bool Stackable
        {
            get { return _stackable; }
            set { _stackable = value; }
        }
        #endregion

        public ItemAsset() : base ()
        {
            IType = ItemType.None;
            Weight = 0;
            Description = String.Empty;
            Stackable = false;
            StackSize = 0;
            Icon = null;
            Level = 1;
            Cost = 0;
        }

        public ItemAsset(int id) : base (id)
        {
            IType = ItemType.None;
            Weight = 0;
            Description = String.Empty;
            Stackable = false;
            StackSize = 0;
            Icon = null;
            Level = 1;
            Cost = 0;
        }

        public ItemAsset(int id, string name) : base(id, name)
        {
            IType = ItemType.None;
            Weight = 0;
            Description = String.Empty;
            Stackable = false;
            StackSize = 0;
            Icon = null;
            Level = 1;
            Cost = 0;
        }

        public ItemAsset(int id, string name, int weight, string description, bool stackable, int stackSize, Sprite icon, int level, int cost) : base(id, name)
        {
            IType = ItemType.None;
            Weight = weight;
            Description = description;
            Stackable = stackable;
            StackSize = stackSize;
            Icon = icon;
            Level = level;
            Cost = cost;
        }
    }
}