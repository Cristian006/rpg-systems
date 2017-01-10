using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Systems.Utility.Database;
using Systems.StatSystem;

namespace Systems.EntitySystem
{
    [System.Serializable]
    public class EntityAsset : BaseDatabaseAsset
    {
        [SerializeField]
        Sprite icon;
        [SerializeField]
        string description;
        [SerializeField]
        List<string> defaultInventory;
        [SerializeField]
        EntityType entityClass;
        [SerializeField]
        PlayerType playerType;

        #region CONSTRUCTORS
        public EntityAsset() : base()
        {
            Icon = null;
            Description = string.Empty;
            defaultInventory = new List<string>();
            EClass = EntityType.None;
            PType = PlayerType.None;
        }

        public EntityAsset(int id) : base(id)
        {
            Icon = null;
            Description = string.Empty;
            defaultInventory = new List<string>();
            EClass = EntityType.None;
            PType = PlayerType.None;
        }

        public EntityAsset(int id, string name) : base(id, name)
        {
            Icon = null;
            Description = string.Empty;
            defaultInventory = new List<string>();
            EClass = EntityType.None;
            PType = PlayerType.None;
        }

        public EntityAsset(int id, string name, string description, EntityType entityClass, PlayerType playerType) : base (id, name)
        {
            Icon = null;
            Description = description;
            defaultInventory = new List<string>();
            EClass = entityClass;
            PType = playerType;
        }

        public EntityAsset(int id, string name, string description, List<string> inventory, EntityType entityClass, PlayerType playerType) : base(id, name)
        {
            Icon = null;
            Description = description;
            defaultInventory = inventory;
            EClass = entityClass;
            PType = playerType;
        }
        #endregion

        #region GETTERS AND SETTERS
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public Sprite Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public List<string> DefualtInventory
        {
            get
            {
                return defaultInventory;
            }
            set
            {
                defaultInventory = value;
            }
        }

        public EntityType EClass
        {
            get
            {
                return entityClass;
            }

            set
            {
                entityClass = value;
            }
        }

        public PlayerType PType
        {
            get
            {
                return playerType;
            }

            set
            {
                playerType = value;
            }
        }
        #endregion
    }
}