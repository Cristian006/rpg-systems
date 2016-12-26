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
            StatName = string.Empty;
            StatBaseValue = 0;
        }

        public Stat(string name, int val)
        {
            StatName = name;
            StatBaseValue = val;
        }
        #endregion

        #region Properties - Getters/Setters
        public string StatName
        {
            get { return _statName; }
            set { _statName = value; }
        }

        public virtual int StatValue
        {
            get { return StatBaseValue; }
        }

        public virtual int StatBaseValue
        {
            get { return _statBaseValue; }
            set { _statBaseValue = value; }
        }
        #endregion

        public override string ToString()
        {
            return "Stat: " + StatName + " Value: " + StatValue;
        }
    }
}