using UnityEngine;
using System.Collections.Generic;
using Systems.Utility.Database;

namespace Systems.ItemSystem
{
    public class ConsumableDatabase : BaseDatabase<ConsumableAsset>
    {
        const string DatabasePath = @"Resources/Systems/ItemSystem/Databases/";
        const string DatabaseName = @"ConsumableDatabase.asset";

        private static ConsumableDatabase _instance = null;

        public static ConsumableDatabase Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GetDatabase<ConsumableDatabase>(DatabasePath, DatabaseName);
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

        static public ConsumableAsset GetAt(int index)
        {
            return Instance.GetAtIndex(index);
        }

        static public ConsumableAsset GetAsset(int id)
        {
            return Instance.GetByID(id);
        }

        static public ConsumableAsset GetAsset(string name)
        {
            return Instance.GetByName(name);
        }

        static public int GetAssetCount()
        {
            return Instance.Count;
        }

        static public Consumable GetItemFromAsset(ConsumableAsset itemAsset)
        {
            return new Consumable(itemAsset);
        }
    }
}
