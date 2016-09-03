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
        private Sprite _icon;

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
        }

        public ItemAsset(int id) : base ()
        {
            IType = ItemType.None;
            Weight = 0;
            Description = String.Empty;
        }

        public ItemAsset(int id, string name) : base(id, name)
        {
            IType = ItemType.None;
            Weight = 0;
            Description = String.Empty;
        }

        public ItemAsset(int id, string name, ItemType iType, int weight, string description, bool stackable) : base(id, name)
        {
            IType = iType;
            Weight = weight;
            Description = description;
            Stackable = stackable;
        }
    }
}