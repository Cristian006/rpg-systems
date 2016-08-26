using UnityEngine;
using System;
using Systems.StatSystem;

public class ModifierTester : MonoBehaviour {
    private StatCollection stats;

    // Use this for initialization
    void Start () {
        stats = new DefaultStatCollection();
        DisplayStatValues();
        //TESTING MODIFIERS
        var health = stats.GetStat<StatModifiable>(StatType.Health);
        health.AddModifier(new StatModBasePercent(1.0f, false));
        health.AddModifier(new StatModBaseAdd(50f));
        health.AddModifier(new StatModTotalPercent(1.0f));
        health.UpdateModifiers();

        Debug.Log("AFTER MODS");
        DisplayStatValues();
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
