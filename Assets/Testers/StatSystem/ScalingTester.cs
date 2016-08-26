using UnityEngine;
using System;
using Systems.StatSystem;

public class ScalingTester : MonoBehaviour {
    private StatCollection stats;
    
    void Start()
    {
        stats = new DefaultStatCollection();
        DisplayStatValues();

        stats.GetStat<StatAttribute>(StatType.Stamina).ScaleStat(20);
        //stats.GetStat<StatAttribute>(StatType.Wisdom).ScaleStat(20);

        Debug.Log("AFTER STAT SCALING");
        DisplayStatValues();        
        
        //INTERFACE CHECKING
        //Debug.Log("INTERFACE CHECKING");
        //var wisdom = stats.GetStat<Stat>(StatType.Wisdom);
        //IStatScalable statScalable = wisdom as IStatScalable;
        //if(statScalable != null)
        //{
        //    statScalable.ScaleStat(16);
        //}
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
                Debug.Log(stat.StatName + " " + stat.StatValue);
            }
        });
    }
}
