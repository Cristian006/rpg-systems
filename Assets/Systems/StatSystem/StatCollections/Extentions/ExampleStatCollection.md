# ExampleStatCollection

class in `Systems.StatSystem` / Inherits from: [StatCollection][1]

### Description

A class that holds a collection of stats in a dictionary.
This is an example configuration of stats.

```csharp
using UnityEngine;
using System.Collections;

public class ExampleStatCollection : StatCollection
{
    //example of what configure stats looks like
    protected override void ConfigureStats()
    {
        //attributes
        var stamina = CreateOrGetStat<StatAttribute>(StatType.Stamina);
        stamina.StatName = "Stamina";
        stamina.StatBaseValue = 3;

        var stength = CreateOrGetStat<StatAttribute>(StatType.Strength);
        stength.StatName = "Strength";
        stength.StatBaseValue = 5;

        //stats linking up to attributes
        var health = CreateOrGetStat<StatRegeneratable>(StatType.Health);
        health.StatName = "Health";
        health.StatBaseValue = 100;
        health.BaseSecondsPerPoint = 100;
        health.AddLinker(new ExampleStatLinker(CreateOrGetStat<StatAttribute>(StatType.Stamina), 10f));

        health.AddLinker(new ExampleStatLinker(CreateOrGetStat<StatAttribute>(StatType.Endurance), 5f, true));
        health.UpdateLinkers();
        health.RestoreCurrentValueToMax();

        var inventory = CreateOrGetStat<StatVital>(StatType.InventoryCap);
        inventory.StatName = "Inventory";
        inventory.StatBaseValue = 5;
        inventory.AddLinker(new ExampleStatLinker(CreateOrGetStat<StatAttribute>(StatType.Strength), 1f));
        inventory.UpdateLinkers();
    }
}
```

## Inherited Members

### Protected Overrided Functions

| Name | Description |
| :--- | :---------- |
| `ConfigureStats` | Called when the stat collection is initialized, this creates all the stats and adds it to the stat dictionary. |

[1]: ../StatCollection.md