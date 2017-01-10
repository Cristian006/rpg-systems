using UnityEngine;
using System.Collections.Generic;
using Systems.Utility.Database;

namespace Systems.ItemSystem
{
    public class WeaponDatabase : BaseDatabase<WeaponAsset>
    {
        const string DatabasePath = @"Resources/Systems/ItemSystem/Databases/";
        const string DatabaseName = @"WeaponDatabase.asset";

        private static WeaponDatabase _instance = null;
        
        public static WeaponDatabase Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = GetDatabase<WeaponDatabase>(DatabasePath, DatabaseName);
                }

                return _instance;
            }
        }

        public static bool ContainsAsset(string name)
        {
            return Instance.Contains(name);
        }

        public static bool ContainsAsset(int id)
        {
            return Instance.Contains(id);
        }

        static public WeaponAsset GetAt(int index)
        {
            return Instance.GetAtIndex(index);
        }

        static public WeaponAsset GetAsset(int id)
        {
            return Instance.GetByID(id);
        }

        static public WeaponAsset GetAsset(string name)
        {
            return Instance.GetByName(name);
        }

        static public int GetAssetCount()
        {
            return Instance.Count;
        }

        static public Weapon GetItemFromAsset(WeaponAsset itemAsset)
        {
            return new Weapon(itemAsset);
        }
    }
}