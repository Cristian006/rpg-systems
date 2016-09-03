using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Systems.Utility.Database;

namespace Systems.StatSystem
{
    [System.Serializable]
    public class BaseStatCollection<T> : BaseDatabaseAsset where T : Stat
    {
        private List<T> _stats;

        public List<T> Stats
        {
            get { return _stats; }
            set { _stats = value; }
        }


    }
}