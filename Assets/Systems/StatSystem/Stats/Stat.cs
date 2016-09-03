using System.Collections;
namespace Systems.StatSystem
{
    public class Stat
    {
        private string _statName;
        private int _statBaseValue;

        public string StatName
        {
            get
            {
                return _statName;
            }
            set
            {
                _statName = value;
            }
        }

        public virtual int StatValue
        {
            get { return StatBaseValue; }
        }

        public virtual int StatBaseValue
        {
            get
            {
                return _statBaseValue;
            }
            set
            {
                _statBaseValue = value;
            }
        }

        public Stat()
        {
            StatName = string.Empty;
            StatBaseValue = 0;
        }

        public Stat(string name, int val)
        {
            StatName = name;
            StatBaseValue = val;
        }

        public override string ToString()
        {
            return "Stat: " + StatName + " Value: " + StatValue;
        }
    }
}