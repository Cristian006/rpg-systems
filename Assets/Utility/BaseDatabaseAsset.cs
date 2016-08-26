using UnityEngine;
using System.Collections;

namespace Systems.Utility.Database
{
    [System.Serializable]
    public class BaseDatabaseAsset : IDatabaseAsset
    {
        [SerializeField]
        private int _id;

        [SerializeField]
        private string _name;

        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public BaseDatabaseAsset()
        {
            this.ID = -1;
            this.Name = string.Empty;
        }

        public BaseDatabaseAsset(int id)
        {
            this.ID = id;
            this.Name = string.Empty;
        }

        public BaseDatabaseAsset(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}

