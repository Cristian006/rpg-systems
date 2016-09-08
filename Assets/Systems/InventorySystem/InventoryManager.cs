using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Systems.ItemSystem;
using Systems.StatSystem;

namespace Systems.InventorySystem
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]
        private Entity entity;

        private InventoryList<Weapon> _weapons;
        private InventoryList<Consumable> _consumables;
        private InventoryList<QuestItem> _questItems;
        
        public InventoryList<T> Inventory<T>() where T : Item
        {
            Type t = typeof(T);

            if(t == typeof(Weapon))
            {
                return _weapons as InventoryList<T>;
            }
            else if(t == typeof(Consumable))
            {
                return _consumables as InventoryList<T>;
            }
            else if(t == typeof(QuestItem))
            {
                return _questItems as InventoryList<T>;
            }
            else
            {
                Debug.Log("No Inventory List matches that type");
                return null;
            }
        }

        #region GETTERS AND SETTERS
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

        public InventoryList<Weapon> Weapons
        {
            get
            {
                if(_weapons == null)
                {
                    _weapons = new InventoryList<Weapon>();
                }
                return _weapons;
            }

            set
            {
                _weapons = value;
            }
        }

        public InventoryList<Consumable> Consumables
        {
            get
            {
                if(_consumables == null)
                {
                    _consumables = new InventoryList<Consumable>();
                }
                return _consumables;
            }

            set
            {
                _consumables = value;
            }
        }

        public InventoryList<QuestItem> QuestItems
        {
            get
            {
                if(_questItems == null)
                {
                    _questItems = new InventoryList<QuestItem>();
                }
                return _questItems;
            }
            set
            {
                _questItems = value;
            }
        }
        #endregion

        #region PROPERTIES
        public int MaxWeight
        {
            get
            {
                return MyEntity.stats.GetStat<StatVital>(StatType.InventoryCap).StatValue;
            }
        }

        public int Weight
        {
            get
            {
                return (Weapons.Weight + Consumables.Weight + QuestItems.Weight);
            }
        }

        public int AvailableWeight
        {
            get
            {
                return (MaxWeight - Weight);
            }
        }

        public int Count
        {
            get
            {
                return (Weapons.Count + Consumables.Count + QuestItems.Count);
            }
        }
        #endregion

        #region METHODS
        public void Add<T>(T item) where T : Item
        {
            if(item.Weight <= AvailableWeight)
            {
                Inventory<T>().Add(item);
            }
            else
            {
                Debug.Log("Can not add anymore Items, too much weight!");
            }
        }

        public void Remove<T>(T item) where T : Item
        {
            Inventory<T>().Remove(item);
        }

        public void RemoveAt<T>(int index) where T : Item
        {
            Inventory<T>().RemoveAt(index);
        }

        public void Replace<T>(int index, T item) where T : Item
        {
            Inventory<T>().Replace(index, item);
        }

        public bool Contains<T>(T item) where T : Item
        {
            return Inventory<T>().Contains(item);
        }

        public bool Contains<T>(int id) where T : Item
        {
            return Inventory<T>().Contains(id);
        }

        public bool Contains<T>(string name) where T : Item
        {
            return Inventory<T>().Contains(name);
        }

        public T GetAt<T>(int index) where T : Item
        {
            return Inventory<T>().GetAt(index);
        }

        public T GetBy<T>(string name) where T : Item
        {
            return Inventory<T>().GetBy(name);
        }

        public T GetBy<T>(int id) where T : Item
        {
            return Inventory<T>().GetBy(id);
        }
        #endregion
    }
}