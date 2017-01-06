using UnityEngine;
using System.Collections;
using Systems.Utility.Database;

namespace Systems.EntitySystem
{
    public class EntityDatabase : BaseDatabase<EntityAsset>
    {
        const string DatabasePath = @"Resources/Systems/EntitySystem/Database/";
        const string DatabaseName = @"EntityDatabase.asset";

        private static EntityDatabase _instance = null;

        public static EntityDatabase Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GetDatabase<EntityDatabase>(DatabasePath, DatabaseName);
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

        static public EntityAsset GetAt(int index)
        {
            return Instance.GetAtIndex(index);
        }

        static public EntityAsset GetAsset(int id)
        {
            return Instance.GetByID(id);
        }

        static public EntityAsset GetAsset(string name)
        {
            return Instance.GetByName(name);
        }

        static public int GetAssetCount()
        {
            return Instance.Count;
        }

        static public EntityData GetDataFromAsset(EntityAsset entityAsset)
        {
            return new EntityData(entityAsset);
        }
    }
}