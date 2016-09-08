using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEditor;

namespace Systems.Utility.Database
{
    public abstract class AbstractDatabase<T> : ScriptableObject where T : IDatabaseAsset
    {
        [SerializeField]
        private List<T> _objects;

        protected List<T> Objects
        {
            get
            {
                if(_objects == null)
                {
                    _objects = new List<T>();
                }
                return _objects;
            }
        }

        protected abstract void OnAddObject(T t);

        protected abstract void OnRemoveObject(T t);


        static public U GetDatabase<U>(string pathToDB, string DBName) where U : ScriptableObject
        {
            #if UNITY_EDITOR
            string dbFullPath = @"Assets/" + pathToDB + DBName;
            U database = AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(U)) as U;

            if (database == null)
            {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/" + pathToDB);
                database = ScriptableObject.CreateInstance<U>();
                AssetDatabase.CreateAsset(database, dbFullPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            return database;
            #else
            Debug.LogFormat("Loading Database at path ({0}) with name {1}", pathToDB, DBName);
            var db = Resources.Load<U>(pathToDB.Replace("Resources/", "") + DBName.Replace(".asset", ""));
            if(db == null){
                Debug.Log("No Database Found");
                return null;
            }
            else
            {
                Debug.Log("All Good");
                return db;
            }
            #endif
        }

        public void Add(T t)
        {
            Objects.Add(t);
            OnAddObject(t);
        }

        public void Remove(T t)
        {
            Objects.Remove(t);
            OnRemoveObject(t);
        }

        public void RemoveAt(int index)
        {
           var obj = Objects[index];
            Objects.RemoveAt(index);
            OnRemoveObject(obj);
        }

        public void Replace(int index, T t)
        {
            var old = Objects[index];
            Objects[index] = t;
            OnRemoveObject(old);
            OnAddObject(t);
        }

        public bool Contains(T t)
        {
            return Objects.Contains(t);
        }

        public bool Contains(int id)
        {
            for (int i = 0; i < Count; i++)
            {
                var asset = GetAtIndex(i);
                if (asset.ID == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(string name)
        {
            for (int i = 0; i < Count; i++)
            {
                var asset = GetAtIndex(i);
                if (asset.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public int Count
        {
            get { return Objects.Count; }
        }

        public T GetAtIndex(int index)
        {
            if(this.Count > 0)
            {
                if(index >= 0 && index < this.Count)
                {
                    return Objects[index];
                }
                else
                {
                    return default(T);
                }
            }
            return default(T);
        }

        public T GetByID(int id)
        {
            for(int i = 0; i < Count; i++)
            {
                var asset = GetAtIndex(i);
                if(asset.ID == id)
                {
                    return (T)GetAtIndex(i);
                }
            }
            return default(T);
        }

        public T GetByName(string name)
        {
            for (int i = 0; i < Count; i++)
            {
                var asset = GetAtIndex(i);
                if (asset.Name == name)
                {
                    return (T)GetAtIndex(i);
                }
            }
            return default(T);
        }

        public int GetFirstAvalibleId()
        {
            if (Count <= 0)
            {
                return 1;
            }
            else {
                int target = 1;
                bool found = false;
                while (!found)
                {
                    found = true;
                    for (int i = 0; i < Count; i++)
                    {
                        if (GetAtIndex(i).ID == target)
                        {
                            found = false;
                            target++;
                            break;
                        }
                    }
                }
                return target;
            }
        }

        public int GetNextId()
        {
            if (Count <= 0)
            {
                return 1;
            }
            else {
                int maxId = 1;
                for (int i = 0; i < Count; i++)
                {
                    var asset = GetAtIndex(i);
                    if (asset.ID > maxId)
                    {
                        maxId = asset.ID;
                    }
                }
                return maxId + 1;
          }
        }

        public bool ContainsDuplicateId()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                var asset1 = GetAtIndex(i);
                for (int j = i + 1; j < Count; j++)
                {
                    var asset2 = GetAtIndex(j);
                    if (asset1.ID == asset2.ID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}