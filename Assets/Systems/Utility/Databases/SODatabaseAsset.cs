using UnityEngine;
using System.Collections;
using System;

namespace Systems.Utility.Database
{
    public class SODatabaseAsset : ScriptableObject, IDatabaseAsset
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


        public SODatabaseAsset()
        {
            this.ID = -1;
            this.Name = string.Empty;
        }

        public SODatabaseAsset(int id)
        {
            this.ID = id;
            this.Name = string.Empty;
        }

        public SODatabaseAsset(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}