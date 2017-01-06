using UnityEngine;
using System.Collections;
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
        EntityType entityClass;
        [SerializeField]
        PlayerType playerType;

        #region CONSTRUCTORS
        public EntityAsset() : base()
        {
            Icon = null;
            Description = string.Empty;
            EClass = EntityType.None;
            PType = PlayerType.None;
        }

        public EntityAsset(int id) : base(id)
        {
            Icon = null;
            Description = string.Empty;
            EClass = EntityType.None;
            PType = PlayerType.None;
        }

        public EntityAsset(int id, string name) : base(id, name)
        {
            Icon = null;
            Description = string.Empty;
            EClass = EntityType.None;
            PType = PlayerType.None;
        }

        public EntityAsset(int id, string name, string description, EntityType entityClass, PlayerType playerType) : base (id, name)
        {
            Icon = null;
            Description = description;
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