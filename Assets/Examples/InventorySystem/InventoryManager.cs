using UnityEngine;
using Systems.StatSystem;

namespace Systems.Example
{
    public class InventoryManager : InventorySystem.InventoryManager
    {
        [SerializeField]
        private Entity entity;

        public Entity MyEntity
        {
            get
            {
                if (entity == null)
                {
                    entity = GetComponent<Entity>();
                }
                return entity;
            }
        }


        public override int MaxWeight
        {
            get
            {
               return MyEntity.Stats.GetStat<StatVital>(StatType.InventoryCap).Max;
            }
        }
    }
}