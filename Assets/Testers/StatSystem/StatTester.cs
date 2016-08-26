using UnityEngine;
using System;
using Systems.StatSystem;

public class StatTester : MonoBehaviour {
    private StatCollection stats;

    void Start()
    {
        //TESTING STAT CREATION
        stats = new DefaultStatCollection();
        DisplayStatValues();
    }

    void ForEachEnum<T>(Action<T> action)
    {
        if(action != null)
        {
            var statTypes = Enum.GetValues(typeof(T));
            foreach(var statType in statTypes)
            {
                action((T)statType);
            }
        }
    }

    void DisplayStatValues()
    {
        ForEachEnum<StatType>((statType) => {
            Stat stat = stats.GetStat((StatType)statType);
            if(stat != null)
            {
                Debug.Log(stat.StatName + " " + stat.StatValue);
            }
        });
    }
}