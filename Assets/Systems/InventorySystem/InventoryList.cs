using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Systems.ItemSystem;
using Systems.Utility.Database.Interfaces;
using System;

namespace Systems.InventorySystem
{
    public class InventoryList<T> : IDatabaseMethods<T> where T : Item
    {
        private List<T> _objects;

        public List<T> Objects
        {
            get
            {
                if (_objects == null)
                {
                    _objects = new List<T>();
                }
                return _objects;
            }
        }

        public int Weight
        {
            get
            {
                int total = 0;
                foreach (var i in Objects)
                {
                    total += i.Weight;
                }
                return total;
            }
        }

        public int Count
        {
            get
            {
                return Objects.Count;
            }
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
            if(index >= 0 && index < Count)
            {
                var obj = Objects[index];
                Objects.RemoveAt(index);
                OnRemoveObject(obj);
            }
            else
            {
                Debug.Log("The index of the object you are trying to remove is out of range");
            }
        }

        public void Replace(int index, T t)
        {
            if (index >= 0 && index < Count)
            {
                var old = Objects[index];
                Objects[index] = t;
                OnRemoveObject(old);
                OnAddObject(t);
            }
            else
            {
                Debug.Log("The index of the object you are trying to replace is out of range");
            }
        }

        public bool Contains(T t)
        {
            return Objects.Contains(t);
        }

        public bool Contains(int id)
        {
            for (int i = 0; i < Count; i++)
            {
                var asset = GetAt(i);
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
                var asset = GetAt(i);
                if (asset.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public T GetAt(int index)
        {
            if (this.Count > 0)
            {
                if (index >= 0 && index < this.Count)
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

        public T GetBy(string name)
        {
            for (int i = 0; i < Count; i++)
            {
                var asset = GetAt(i);
                if (asset.Name == name)
                {
                    return (T)GetAt(i);
                }
            }
            return default(T);
        }

        public T GetBy(int id)
        {
            for (int i = 0; i < Count; i++)
            {
                var asset = GetAt(i);
                if (asset.ID == id)
                {
                    return (T)GetAt(i);
                }
            }
            return default(T);
        }
        
        public void OnAddObject(T t)
        {

        }

        public void OnRemoveObject(T t)
        {

        }
    }
}