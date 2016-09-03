using UnityEngine;
using System.Collections.Generic;
using Systems.Utility.Database;

namespace Systems.ItemSystem
{
    public class QuestDatabase : BaseDatabase<QuestAsset>
    {
        const string DatabasePath = @"Resources/Systems/ItemSystem/Databases/";
        const string DatabaseName = @"QuestDatabase.asset";

        private static QuestDatabase _instance = null;

        public static QuestDatabase Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GetDatabase<QuestDatabase>(DatabasePath, DatabaseName);
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

        static public ItemAsset GetAt(int index)
        {
            return Instance.GetAtIndex(index);
        }

        static public ItemAsset GetAsset(int id)
        {
            return Instance.GetByID(id);
        }

        static public ItemAsset GetAsset(string name)
        {
            return Instance.GetByName(name);
        }

        static public int GetAssetCount()
        {
            return Instance.Count;
        }

        static public Item GetItemFromAsset(ItemAsset itemAsset)
        {
            return null;//new Item(itemAsset);
        }
    }
}