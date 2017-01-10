using System.Collections;

namespace Systems.StatSystem
{
    //Stat contains only a base value and name variable
    public class Stat
    {
        private string _statName;
        private int _statBaseValue;

        #region Constructors
        public Stat()
        {
            //empty constructor
            Name = string.Empty;
            BaseValue = 0;
        }

        public Stat(string name, int val)
        {
            Name = name;
            BaseValue = val;
        }
        #endregion

        #region Properties - Getters/Setters
        public string Name
        {
            get { return _statName; }
            set { _statName = value; }
        }

        public virtual int Value
        {
            get { return BaseValue; }
        }

        public virtual int BaseValue
        {
            get { return _statBaseValue; }
            set { _statBaseValue = value; }
        }
        #endregion

        public override string ToString()
        {
            return "Stat: " + Name + " Value: " + Value;
        }
    }
}