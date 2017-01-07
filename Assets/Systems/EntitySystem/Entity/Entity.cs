using UnityEngine;
using Systems.StatSystem;
using UnityEngine.UI;
using System.Collections;

namespace Systems.EntitySystem
{
    public class EntityData
    {
        public EntityData()
        {
            entityName = string.Empty;
            entityClass = EntityType.None;
            playerType = PlayerType.None;
        }

        public EntityData(EntityAsset entityAsset)
        {
            entityName = entityAsset.Name;
            entityDescription = entityAsset.Description;
            entityClass = entityAsset.EClass;
            playerType = entityAsset.PType;
            entityImage = entityAsset.Icon;
        }

        public Sprite entityImage;
        public string entityName;
        public string entityDescription;
        public EntityType entityClass;
        public PlayerType playerType;

    }

    //Entity is simply a script that has an associated StatCollection
    //Gives children a method to get the stats it needs
    public abstract class Entity : MonoBehaviour
    {
        private StatCollection stats;
        private EntityLevel level;
        private EntityData data;

        public StatCollection Stats
        {
            get
            {
                if (stats == null)
                {
                    stats = GetComponent<StatCollection>();
                }

                return stats;
            }
            set { stats = value; }
        }

        public EntityLevel Level
        {
            get
            {
                if (level == null)
                {
                    level = GetComponent<EntityLevel>();
                }
                return level;
            }
            set
            {
                level = value;
            }
        }

        public EntityData Data
        {
            get
            {
                if (data == null)
                {
                    data = new EntityData();
                }
                return data;
            }
            set
            {
                data = value;
            }
        }

        protected T GetStat<T>(StatType type) where T : Stat
        {
            return stats.GetStat<T>(type);
        }

        //require children to initialize
        protected abstract void Awake();
    }
}