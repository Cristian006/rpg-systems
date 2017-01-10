using UnityEngine;
using System;
using System.Collections.Generic;

namespace Systems.StatSystem
{
    public abstract class StatCollection : MonoBehaviour
    {
        private Dictionary<StatType, Stat> _statDictionary;

        #region Constructors
        public StatCollection()
        {
            _statDictionary = new Dictionary<StatType, Stat>();
        }
        #endregion

        #region Properties - Getters/Setters
        public Dictionary<StatType, Stat> StatDict
        {
            get
            {
                if (_statDictionary == null)
                {
                    //initialize the stat collection if it hasn't already
                    _statDictionary = new Dictionary<StatType, Stat>();
                    ConfigureStats();
                }

                return _statDictionary;
            }
        }

        //Gets the coresponding stat if it's in the collection
        //read only
        protected Stat this[StatType statType]
        {
            get
            {
                if (ContainsStat(statType))
                {
                    return StatDict[statType];
                }
                return null;
            }
        }

        /// <summary>
        /// Returns a List of all regenerating stats
        /// </summary>
        /// <returns></returns>
        public List<StatRegeneratable> GetAllRegeneratingStats
        {
            get
            {
                List<StatRegeneratable> re = new List<StatRegeneratable>();

                //INTERFACE CHECKING FOR STAT REGEN ABILITY
                foreach (var i in StatDict.Keys)
                {
                    var stat = this[(StatType)i];
                    IStatRegeneratable s = stat as IStatRegeneratable;
                    if (s != null)
                    {
                        re.Add(stat as StatRegeneratable);
                    }
                }
                return re;
            }
        }
        #endregion

        void Awake()
        {
            ConfigureStats();
        }

        //regenerating stats
        void FixedUpdate()
        {
            RegenStats();
        }

        //Only way to make regen stats work
        void RegenStats()
        {
            foreach (var i in GetAllRegeneratingStats)
            {
                if (i.StatCurrentValue != i.Value)
                {
                    if (Time.time > i.TimeForNextRegen)
                    {
                        i.Regenerate();
                        i.TimeForNextRegen = Time.time + i.SecondsPerPoint;
                    }
                }
            }
        }

        protected abstract void ConfigureStats();

        //Check for stat in collection
        public bool ContainsStat(StatType statType)
        {
            return StatDict.ContainsKey(statType);
        }

        
        //returns a Stat of Type T
        public T GetStat<T>(StatType type) where T : Stat
        {
            //return GetStat(type) as T;
            return this[type] as T;
        }

        //Creates the <T> Stat and adds it to the collection
        protected T CreateStat<T>(StatType statType) where T : Stat
        {
            T stat = Activator.CreateInstance<T>();
            //Debug.Log("CREATING STAT OF TYPE " + statType + ": " + stat.ToString());
            StatDict.Add(statType, stat);
            return stat;
        }

        //This method returns a stat and if it's not in the collection it creates it and adds it to the collection
        protected T CreateOrGetStat<T>(StatType statType) where T : Stat
        {
            T stat = GetStat<T>(statType);
            if (stat == null)
            {
                stat = CreateStat<T>(statType);
                //Debug.Log("GOT STAT BACK: " + stat.ToString());
            }
            return stat;
        }

        /// <summary>
        /// Adds a Stat Modifier to the Target stat.
        /// </summary>
        public void AddStatModifier(StatType target, StatModifier mod)
        {
            AddStatModifier(target, mod, false);
        }

        /// <summary>
        /// Adds a Stat Modifier to the Target stat and then updates the stat's value.
        /// </summary>
        public void AddStatModifier(StatType target, StatModifier mod, bool update)
        {
            if (ContainsStat(target))
            {
                var modStat = this[target] as IStatModifiable;
                if (modStat != null)
                {
                    modStat.AddModifier(mod);
                    if (update == true)
                    {
                        modStat.UpdateModifiers();
                    }
                }
                else {
                    Debug.Log("[Stats] Trying to add Stat Modifier to non modifiable stat \"" + target.ToString() + "\"");
                }
            }
            else {
                Debug.Log("[Stats] Trying to add Stat Modifier to \"" + target.ToString() + "\", but Stats does not contain that stat");
            }
        }

        /// <summary>
        /// Removes a Stat Modifier to the Target stat.
        /// </summary>
        public void RemoveStatModifier(StatType target, StatModifier mod)
        {
            RemoveStatModifier(target, mod, false);
        }

        /// <summary>
        /// Removes a Stat Modifier to the Target stat and then updates the stat's value.
        /// </summary>
        public void RemoveStatModifier(StatType target, StatModifier mod, bool update)
        {
            if (ContainsStat(target))
            {
                var modStat = this[target] as IStatModifiable;
                if (modStat != null)
                {
                    modStat.RemoveModifier(mod);
                    if (update == true)
                    {
                        modStat.UpdateModifiers();
                    }
                }
                else {
                    Debug.Log("[Stats] Trying to remove Stat Modifier from non modifiable stat \"" + target.ToString() + "\"");
                }
            }
            else {
                Debug.Log("[Stats] Trying to remove Stat Modifier from \"" + target.ToString() + "\", but StatCollection does not contain that stat");
            }
        }

        /// <summary>
        /// Clears all stat modifiers from all stats in the collection.
        /// </summary>
        public void ClearStatModifiers()
        {
            ClearStatModifiers(false);
        }

        /// <summary>
        /// Clears all stat modifiers from all stats in the collection then updates all the stat's values.
        /// </summary>
        /// <param name="update"></param>
        public void ClearStatModifiers(bool update)
        {
            foreach (var key in StatDict.Keys)
            {
                ClearStatModifier(key, update);
            }
        }

        /// <summary>
        /// Clears all stat modifiers from the target stat.
        /// </summary>
        public void ClearStatModifier(StatType target)
        {
            ClearStatModifier(target, false);
        }

        /// <summary>
        /// Clears all stat modifiers from the target stat then updates the stat's value.
        /// </summary>
        public void ClearStatModifier(StatType target, bool update)
        {
            if (ContainsStat(target))
            {
                var modStat = this[target] as IStatModifiable;
                if (modStat != null)
                {
                    modStat.ClearModifiers();
                    if (update == true)
                    {
                        modStat.UpdateModifiers();
                    }
                }
                else {
                    Debug.Log("[Stats] Trying to clear Stat Modifiers from non modifiable stat \"" + target.ToString() + "\"");
                }
            }
            else {
                Debug.Log("[Stats] Trying to clear Stat Modifiers from \"" + target.ToString() + "\", but StatCollection does not contain that stat");
            }
        }

        /// <summary>
        /// Updates all stat modifier's values
        /// </summary>
        public void UpdateStatModifiers()
        {
            foreach (var key in StatDict.Keys)
            {
                UpdateStatModifer(key);
            }
        }

        /// <summary>
        /// Updates the target stat's modifier value
        /// </summary>
        public void UpdateStatModifer(StatType target)
        {
            if (ContainsStat(target))
            {
                var modStat = this[target] as IStatModifiable;
                if (modStat != null)
                {
                    modStat.UpdateModifiers();
                }
                else {
                    Debug.Log("[Stats] Trying to Update Stat Modifiers for a non modifiable stat \"" + target.ToString() + "\"");
                }
            }
            else {
                Debug.Log("[Stats] Trying to Update Stat Modifiers for \"" + target.ToString() + "\", but StatCollection does not contain that stat");
            }
        }

        /// <summary>
        /// Scales all stats in the collection to the same target level
        /// </summary>
        public void ScaleStatCollection(int level)
        {
            foreach (var key in StatDict.Keys)
            {
                ScaleStat(key, level);
            }
        }

        /// <summary>
        /// Scales the target stat in the collection to the target level
        /// </summary>
        public void ScaleStat(StatType target, int level)
        {
            if (ContainsStat(target))
            {
                var stat = this[target] as IStatScalable;
                if (stat != null)
                {
                    stat.ScaleStat(level);
                }
                else {
                    Debug.Log("[RPGStats] Trying to Scale Stat with a non scalable stat \"" + target.ToString() + "\"");
                }
            }
            else {
                Debug.Log("[RPGStats] Trying to Scale Stat for \"" + target.ToString() + "\", but RPGStatCollection does not contain that stat");
            }
        }

        public override string ToString()
        {
            string i = string.Empty;
            foreach (var key in StatDict.Keys)
            {
                var stat = this[key];
                i += stat.StatName + ": " + stat.Value + "\n";
            }
            return i;
        }
    }
}