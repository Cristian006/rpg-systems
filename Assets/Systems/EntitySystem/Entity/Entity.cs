using UnityEngine;
using Systems.StatSystem;
using System.Collections;

namespace Systems.EntitySystem
{
    public class Entity : MonoBehaviour
    {
        public string entityName;
        public string Description;
        public EntityLevel level;
        public StatCollection stats;
        public EntityClass entityClass;
        public PlayerType playerType;
        
        public Entity()
        {

        }

        public Entity(EntityAsset entityAsset)
        {
            entityName = entityAsset.Name;
            entityClass = entityAsset.EClass;
            playerType = entityAsset.PType;            
        }

        void Awake()
        {
            if (level == null)
            {
                level = GetComponent<EntityLevel>();
                if (level == null)
                {
                    Debug.LogWarning("No Entity Level Assigned to this Entity");
                }
            }
            if (stats == null)
            {
                stats = GetComponent<BaseStatCollection>();
                if (stats == null)
                {
                    Debug.LogWarning("No Stat Collection Assigned to this Entity");
                }
            }
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
            stats.GetStat<StatRegen>(StatType.Health).StatCurrentValue += amount;
        }

        public void RestoreHealth()
        {
            stats.GetStat<StatRegen>(StatType.Health).RestoreCurrentValueToMax();
        }
    }
}