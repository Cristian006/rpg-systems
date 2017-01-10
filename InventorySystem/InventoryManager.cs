using UnityEngine;
using System;
using Systems.ItemSystem;
using Systems.EntitySystem;

//TODO: Event handlers for weapon change
namespace Systems.InventorySystem
{
    public abstract class InventoryManager : MonoBehaviour
    {
        [SerializeField]
        private Entity entity;
        [SerializeField]
        private Inventory _inventory;

        public EventHandler OnPrimaryChange;
        public EventHandler OnSecondaryChange;
        public EventHandler OnTertiaryChange;
        public EventHandler OnEquippedChange;

        public EventHandler OnItemRemovedSuccess;
        public EventHandler OnItemRemovdFailure;

        public EventHandler OnItemAddedSuccess;
        public EventHandler OnItemAddedFailure;

        public EventHandler OnInventoryChange;

        private int _primaryIndex = -1;
        private int _secondaryIndex = -1;
        private int _tertiaryIndex = -1;

        #region GETTERS AND SETTERS
        private Inventory inventory
        {
            get
            {
                if (_inventory == null)
                {
                    _inventory = new Inventory();
                }
                return _inventory;
            }
            set
            {
                _inventory = value;
            }
        }

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

        public int PrimaryIndex
        {
            get
            {
                return _primaryIndex;
            }
            set
            {
                _primaryIndex = value;
            }
        }

        public int SecondaryIndex
        {
            get
            {
                return _secondaryIndex;
            }

            set
            {
                _secondaryIndex = value;
            }
        }

        public int TertiaryIndex
        {
            get
            {
                return _tertiaryIndex;
            }

            set
            {
                _tertiaryIndex = value;
            }
        }

        public bool PrimarySlotEquipped
        {
            get
            {
                return PrimaryIndex >= 0 ? true : false;
            }
        }

        public bool SecondarySlotEquipped
        {
            get
            {
                return SecondaryIndex >= 0 ? true : false;
            }
        }

        public bool TertiarySlotEquipped
        {
            get
            {
                return TertiaryIndex >= 0 ? true : false;
            }
        }
        #endregion

        #region PROPERTIES
        public Weapon Primary
        {
            get
            {
                return _primaryIndex >= 0 ? inventory.Objects<Weapon>().GetAt(_primaryIndex) : null;
            }
        }

        public Weapon Secondary
        {
            get
            {
                return _secondaryIndex >= 0 ? inventory.Objects<Weapon>().GetAt(_secondaryIndex) : null;
            }
        }

        public QuestItem Tertiary
        {
            get
            {
                return _tertiaryIndex >= 0 ? inventory.Objects<QuestItem>().GetAt(_tertiaryIndex) : null;
            }
        }

        public InventoryList<Weapon> Weapons
        {
            get
            {
                return inventory.Weapons;
            }
        }

        public InventoryList<Consumable> Consumables
        {
            get
            {
                return inventory.Consumables;
            }
        }

        public InventoryList<QuestItem> QuestItems
        {
            get
            {
                return inventory.QuestItems;
            }
        }

        /// <summary>
        /// The inventory's current weight
        /// </summary>
        public int CurrentWeight
        {
            get
            {
                return inventory.Weight;
            }
        }

        /// <summary>
        /// The inventory's Max Weight
        /// </summary>
        public abstract int MaxWeight
        {
            get;
        }

        /// <summary>
        /// The inventory's available weight
        /// </summary>
        public int AvailableWeight
        {
            get
            {
                return (MaxWeight - CurrentWeight);
            }
        }

        /// <summary>
        /// The respective inventory list count
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int Count<T>() where T : Item
        {
            return inventory.Objects<T>().Count;
        }
        #endregion

        #region INVENTORY METHODS
        /// <summary>
        /// Add Item to inventory if there's enough room.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void Add<T>(T item) where T : Item
        {
            if (item.Weight <= AvailableWeight)
            {
                inventory.Objects<T>().Add(item);
                TriggerOnItemAdded(true);
            }
            else
            {
                TriggerOnItemAdded(false);
                Debug.Log("Cannot add anymore Items, too much weight!");
            }
        }

        /// <summary>
        /// Remove Item from the inventory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void Remove<T>(T item) where T : Item
        {
            if (item != null)
            {
                inventory.Objects<T>().Remove(item);
                TriggerOnItemRemoved(true);
            }
            else
            {
                TriggerOnItemRemoved(false);
            }
        }

        /// <summary>
        /// Remove Item from the inventory at that index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        public void RemoveAt<T>(int index) where T : Item
        {
            inventory.Objects<T>().RemoveAt(index);
            TriggerOnItemRemoved(true);
        }

        /// <summary>
        /// Replace the Item at that index if the difference in weight of the two items fit in the Inventory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Replace<T>(int index, T item) where T : Item
        {
            int differnceInWeight = inventory.Objects<T>().GetAt(index).Weight - item.Weight;

            if ((inventory.Weight - differnceInWeight) <= MaxWeight)
            {
                inventory.Objects<T>().Replace(index, item);
                TriggerOnItemRemoved(true);
            }
            else
            {
                TriggerOnItemRemoved(false);
                Debug.Log("CANNOT REPLACE ITEM, TOO MUCH WEIGHT");
            }
        }

        public bool Contains<T>(T item) where T : Item
        {
            return inventory.Objects<T>().Contains(item);
        }

        public bool Contains<T>(int id) where T : Item
        {
            return inventory.Objects<T>().Contains(id);
        }

        public bool Contains<T>(string name) where T : Item
        {
            return inventory.Objects<T>().Contains(name);
        }

        public T GetAt<T>(int index) where T : Item
        {
            return inventory.Objects<T>().GetAt(index);
        }

        public T GetBy<T>(string name) where T : Item
        {
            return inventory.Objects<T>().GetBy(name);
        }

        public T GetBy<T>(int id) where T : Item
        {
            return inventory.Objects<T>().GetBy(id);
        }
        #endregion

        #region EQUIPPING METHODS
        //check if there is another weapon in inventory to equip
        public bool checkForWeapon(bool primary)
        {
            int currentIndex = primary ? (PrimarySlotEquipped ? PrimaryIndex : 0) : (SecondarySlotEquipped ? SecondaryIndex : 0);

            int inventoryCount = inventory.Count;

            for (int i = currentIndex + 1; i < (inventoryCount * 2); i++)
            {
                int ii = (i % inventoryCount);
                if (Weapons.Objects[(ii)].IType == ItemType.Weapon)
                {
                    if (((Weapon)Weapons.Objects[(ii)]).WeaponType == (primary ? WeaponType.Primary : WeaponType.Secondary))
                    {
                        return ii == currentIndex ? false : true;
                    }
                }
            }
            return false;
        }
        
        public bool isEquipped(Item item)
        {
            switch (item.IType)
            {
                case ItemType.Weapon:
                    if ((item as Weapon).WeaponType == WeaponType.Primary)
                    {
                        return PrimaryIndex == Weapons.Objects.IndexOf((Weapon)item);
                    }
                    else
                    {
                        return SecondaryIndex == Weapons.Objects.IndexOf((Weapon)item);
                    }
                case ItemType.Consumable:
                    return false;
                case ItemType.Quest:
                    return TertiaryIndex == QuestItems.Objects.IndexOf((QuestItem)item);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Equip an Item
        /// false to unequip
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="index"></param>
        /// <param name="equip"></param>
        public void Equip<T>(T item, int index, bool equip) where T : Item
        {
            Type t = typeof(T);

            if (t == typeof(Weapon))
            {
                Debug.Log("Item trying to equip is a weapon");
                if ((item as Weapon).WeaponType == WeaponType.Primary)
                {
                    Debug.Log("Setting it as a Primary Weapon");
                    PrimaryIndex = equip ? index : -1;
                    TriggerPrimaryChange();
                    TriggerOnEquippedChange();
                }
                else
                {
                    SecondaryIndex = equip ? index : -1;
                    TriggerSecondaryChange();
                    TriggerOnEquippedChange();
                }
            }
            else if (t == typeof(QuestItem))
            {
                TertiaryIndex = equip ? index : -1;
                TriggerTertiaryChange();
                TriggerOnEquippedChange();
            }
            else
            {
                Debug.Log("CANNOT EQUIP THIS TYPE OF ITEM");
            }
        }

        public void Equip<T>(T item, int index) where T : Item
        {
            Equip<T>(item, index, true);
        }

        public void Equip(Item item, bool equip = true)
        {
            switch (item.IType)
            {
                case ItemType.Weapon:
                    Debug.Log("Equipping Weapon");
                    Equip<Weapon>((Weapon)item, Weapons.Objects.IndexOf((Weapon)item), equip);
                    break;
                case ItemType.Consumable:
                    Equip<Consumable>((Consumable)item, Consumables.Objects.IndexOf((Consumable)item), equip);
                    break;
                case ItemType.Quest:
                    Equip<QuestItem>((QuestItem)item, QuestItems.Objects.IndexOf((QuestItem)item), equip);
                    break;
            }
        }
        #endregion

        #region EVENT HANDLERS
        void TriggerPrimaryChange()
        {
            if (OnPrimaryChange != null)
            {
                OnPrimaryChange(this, null);
            }
        }
        void TriggerSecondaryChange()
        {
            if (OnSecondaryChange != null)
            {
                OnSecondaryChange(this, null);
            }
        }
        void TriggerTertiaryChange()
        {
            if (OnTertiaryChange != null)
            {
                OnTertiaryChange(this, null);
            }
        }

        void TriggerOnItemAdded(bool itemWasAdded)
        {
            if (itemWasAdded)
            {
                TriggerInventoryChange();
                if (OnItemAddedSuccess != null)
                {
                    OnItemAddedSuccess(this, null);
                }
            }
            else
            {
                if (OnItemAddedFailure != null)
                {
                    OnItemAddedFailure(this, null);
                }
            }

        }

        void TriggerOnItemRemoved(bool itemWasRemoved)
        {
            if (itemWasRemoved)
            {
                TriggerInventoryChange();
                if (OnItemRemovedSuccess != null)
                {
                    OnItemRemovedSuccess(this, null);
                }
            }
            else
            {
                if (OnItemRemovdFailure != null)
                {
                    OnItemRemovedSuccess(this, null);
                }
            }

        }

        void TriggerInventoryChange()
        {
            if (OnInventoryChange != null)
            {
                OnInventoryChange(this, null);
            }
        }

        void TriggerOnEquippedChange()
        {
            if (OnEquippedChange != null)
            {
                OnEquippedChange(this, null);
            }
        }
        #endregion
    }
}