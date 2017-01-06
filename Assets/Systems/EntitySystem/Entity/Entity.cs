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

    public class Entity : MonoBehaviour
    {
        private StatCollection stats;
        private EntityLevel level;
        private EntityData data;

        public StatCollection Stats
        {
            get
            {
                if(stats == null)
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
                if(level == null)
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

        public EntityData Data {
            get
            {
                if(data == null)
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

        void Awake()
        {
            
        }

        public void TakeDamage(int amount)
        {
            if (stats.GetStat<StatVital>(StatType.Armor).StatCurrentValue > 0)
            {
                int amountToTakeFromArmor = (int)(amount * (0.01f * stats.GetStat<StatAttribute>(StatType.ArmorProtection).StatValue));
                int amountToTakeFromHealth = (amount - amountToTakeFromArmor);
                int amountLeft = 0;

                if (stats.GetStat<StatVital>(StatType.Armor).StatCurrentValue >= amountToTakeFromArmor)
                {
                    stats.GetStat<StatVital>(StatType.Armor).StatCurrentValue -= amountToTakeFromArmor;
                }
                else
                {
                    amountLeft = amountToTakeFromArmor - stats.GetStat<StatVital>(StatType.Armor).StatCurrentValue;
                    stats.GetStat<StatVital>(StatType.Armor).StatCurrentValue = 0;
                }

                stats.GetStat<StatVital>(StatType.Health).StatCurrentValue -= (amountToTakeFromHealth + amountLeft);
            }
        }

        public void RestoreHealth(int amount)
        {
            stats.GetStat<StatRegeneratable>(StatType.Health).StatCurrentValue += amount;
        }

        public void RestoreHealth()
        {
            stats.GetStat<StatRegeneratable>(StatType.Health).RestoreCurrentValueToMax();
        }
    }
}