using UnityEngine;
using System;
using Systems.StatSystem;

public class VitalTester : MonoBehaviour {
    private StatCollection stats;

    void Start()
    {
        //TESTING STAT CREATION
        stats = new DefaultStatCollection();

        //var health = stats.GetStat<StatVital>(StatType.Health);
        //health.OnCurrentValueChanged += OnStatValueChanged;
        DisplayStatValues();
        //health.StatCurrentValue -= 75;
        //DisplayStatValues();
    }

    void OnStatValueChanged(object sender, EventArgs args)
    {
        StatVital vital = (StatVital)sender;
        if(vital != null)
        {
            Debug.Log(string.Format("VITAL {0}'S VALUE WAS CHANGED", vital.StatName));
        }
    }

    void ForEachEnum<T>(Action<T> action)
    {
        if (action != null)
        {
            var statTypes = Enum.GetValues(typeof(T));
            foreach (var statType in statTypes)
            {
                action((T)statType);
            }
        }
    }

    void DisplayStatValues()
    {
        ForEachEnum<StatType>((statType) => {
            Stat stat = stats.GetStat((StatType)statType);
            if (stat != null)
            {
                StatVital vital = stat as StatVital;
                if (vital != null)
                {
                    Debug.Log(vital.StatName + " " + vital.StatCurrentValue + "/" + vital.StatValue);
                }
                else
                {
                    Debug.Log(stat.StatName + " " + stat.StatValue);
                }
            }
        });
    }
}
