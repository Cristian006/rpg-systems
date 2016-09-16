using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Systems.ItemSystem;
using Systems.StatSystem;
using Systems.InventorySystem.Utility;

//TODO: Event handlers for weapon change
namespace Systems.InventorySystem
{
    public class Inventory
    {
        private InventoryList<Weapon> _weapons;
        private InventoryList<Consumable> _consumables;
        private InventoryList<QuestItem> _questItems;

        /// <summary>
        /// The Property to acces all Inventory Lists connected with this inventory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public InventoryList<T> Objects<T>() where T : Item
        {
            Type t = typeof(T);

            if (t == typeof(Weapon))
            {
                return Weapons as InventoryList<T>;
            }
            else if (t == typeof(Consumable))
            {
                return Consumables as InventoryList<T>;
            }
            else if (t == typeof(QuestItem))
            {
                return QuestItems as InventoryList<T>;
            }
            else
            {
                Debug.Log("No Inventory List matches that type");
                return null;
            }
        }

        #region GETTERS AND SETTERS
        public InventoryList<Weapon> Weapons
        {
            get
            {
                if (_weapons == null)
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
                if (_consumables == null)
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
                if (_questItems == null)
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
        /// <summary>
        /// The inventory's current weight
        /// </summary>
        public int Weight
        {
            get
            {
                return (Weapons.Weight + Consumables.Weight + QuestItems.Weight);
            }
        }
        
        /// <summary>
        /// The amount of objects in the inventory
        /// </summary>
        public int Count
        {
            get
            {
                return (Weapons.Count + Consumables.Count + QuestItems.Count);
            }
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Add an Item to the respective Inventory List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void Add<T>(T item) where T : Item
        {
            Objects<T>().Add(item);
        }


        /// <summary>
        /// Remove an Item from the respective Inventory List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void Remove<T>(T item) where T : Item
        {
            Objects<T>().Remove(item);
        }


        /// <summary>
        /// Remove an Item by it's index in the respective list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        public void RemoveAt<T>(int index) where T : Item
        {
            Objects<T>().RemoveAt(index);
        }
        
        /// <summary>
        /// Replace an Item with another via the item's index in it's respective list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Replace<T>(int index, T item) where T : Item
        {
            Objects<T>().Replace(index, item);
        }


        /// <summary>
        /// A check whether the respective list contains an Item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains<T>(T item) where T : Item
        {
            return Objects<T>().Contains(item);
        }

        /// <summary>
        /// A check to see whether the Item with the corresponding ID exists in it's respective list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Contains<T>(int id) where T : Item
        {
            return Objects<T>().Contains(id);
        }

        /// <summary>
        /// A check to see whether the Item with the corresponding Name exists in it's respective list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Contains<T>(string name) where T : Item
        {
            return Objects<T>().Contains(name);
        }


        /// <summary>
        /// Get the Item by index from it's respective list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetAt<T>(int index) where T : Item
        {
            return Objects<T>().GetAt(index);
        }

        /// <summary>
        /// Get the Item by name from it's respective list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetBy<T>(string name) where T : Item
        {
            return Objects<T>().GetBy(name);
        }


        /// <summary>
        /// Get the Item by ID from it's respective list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetBy<T>(int id) where T : Item
        {
            return Objects<T>().GetBy(id);
        }
        #endregion

        public void Load()
        {
            
        }

        public void Save()
        {

        }
    }
}