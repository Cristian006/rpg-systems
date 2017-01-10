using System.Collections;

namespace Systems.StatSystem
{
    //Stat contains only a base value and name variable
    public class Stat
    {
        private string _statName;
        private int _baseValue;

        #region Constructors
        public Stat()
        {
            //empty constructor
            StatName = string.Empty;
            Base = 0;
        }

        public Stat(string name, int val)
        {
            StatName = name;
            Base = val;
        }
        #endregion

        #region Properties - Getters/Setters
        public string StatName
        {
            get { return _statName; }
            set { _statName = value; }
        }

        public virtual int Value
        {
            get { return Base; }
        }

        public virtual int Base
        {
            get { return _baseValue; }
            set { _baseValue = value; }
        }
        #endregion

        public override string ToString()
        {
            return "Stat: " + StatName + " Value: " + Value;
        }
    }
}