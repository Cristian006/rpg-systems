using UnityEngine;
using System.Collections;
using Systems.Utility.Database;

namespace Systems.StatSystem
{
    [System.Serializable]
    public class StatTypeAsset : BaseDatabaseAsset
    {
        [SerializeField]
        private string _shortName;

        [SerializeField]
        private string _description;

        [SerializeField]
        private Sprite _icon;

        public string ShortName
        {
            get
            {
                return _shortName;
            }

            set
            {
                _shortName = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public Sprite Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
            }
        }

        public StatTypeAsset() : base()
        {
            this.ShortName = string.Empty;
            this.Description = string.Empty;
            this.Icon = null;
        }

        public StatTypeAsset(int id) : base(id)
        {
            this.ShortName = string.Empty;
            this.Description = string.Empty;
            this.Icon = null;
        }

        public StatTypeAsset(int id, string name) : base(id, name)
        {
            this.ShortName = string.Empty;
            this.Description = string.Empty;
            this.Icon = null;
        }

        public StatTypeAsset(int id, string name, string shortName, string description, Sprite icon) : base(id, name)
        {
            this.ShortName = shortName;
            this.Description = description;
            this.Icon = icon;
        }
    }
}