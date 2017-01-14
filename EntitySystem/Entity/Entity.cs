using UnityEngine;
using Systems.StatSystem;
using UnityEngine.UI;
using System.Collections;
using Systems.EntitySystem.Interfaces;
namespace Systems.EntitySystem
{
    public class EntityData
    {
        public EntityData()
        {
            entityName = string.Empty;
            entityType = EntityType.None;
            playerType = PlayerType.None;
        }

        public EntityData(EntityAsset entityAsset)
        {
            entityName = entityAsset.Name;
            entityDescription = entityAsset.Description;
            entityType = entityAsset.EClass;
            playerType = entityAsset.PType;
            entityImage = entityAsset.Icon;
        }

        public Sprite entityImage;
        public string entityName;
        public string entityDescription;
        public EntityType entityType;
        public PlayerType playerType;

    }

    //Entity is simply a script that has an associated StatCollection
    //Gives children a method to get the stats it needs
    public abstract class Entity : MonoBehaviour, ITarget
    {
        private StatCollection stats;
        private EntityLevel level;
        private EntityData data;
        private Target _target;

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
            protected set { stats = value; }
        }

        public Target target
        {
            get
            {
                if (_target == null)
                {
                    _target = new Target();
                }
                return _target;
            }
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
            return Stats.GetStat<T>(type);
        }

        //require children to initialize
        protected abstract void Awake();
    }
}