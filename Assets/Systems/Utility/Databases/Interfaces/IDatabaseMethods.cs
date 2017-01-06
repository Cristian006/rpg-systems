using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Systems.ItemSystem;

namespace Systems.Utility.Database.Interfaces
{
    public interface IDatabaseMethods<T>
    {
        void Add(T t);

        void Remove(T t);

        void RemoveAt(int index);

        void Replace(int index, T t);

        bool Contains(T t);

        bool Contains(int id);

        bool Contains(string name);

        T GetAt(int index);

        T GetBy(string name);

        T GetBy(int id);

        void OnAddObject(T t);

        void OnRemoveObject(T t);
    }
}