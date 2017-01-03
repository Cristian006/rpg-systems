# StatCollection

class in `Systems.StatSystem` / Inherits from: [MonoBehaviour][1]

### Description

A class that holds a collection of stats in a dictionary

```csharp
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
    public Stat health;
    void Example() {
        //make Example
    }
}
```

### Public Properties

| Name | Description |
| :--- | :---------- |
| `StatDict` | returns a Dictionary of stats |


### Public Functions

| Name | Description |
| :--- | :---------- |
| `GetStat<T>(StatType type)` | returns a stat of type <T> |
| `AddStatModifier(StatType target, StatModifier mod, bool update)` | Adds a Stat Modifier to the Target stat and then updates the stat's value. |
| `RemoveStatModifier(StatType target, StatModifier mod, bool update)` | Removes a Stat Modifier to the Target stat and then updates the stat's value. |
| `ClearStatModifiers(bool update)` | Clears all stat modifiers from all stats in the collection. |
| `ClearStatModifier(StatType target, bool update)` | Clears all stat modifiers from the target stat then updates the stat's value. |
| `UpdateStatModifiers()` | Updates all stat modifier's values |
| `UpdateStatModifier(StatType target)` | Updates the target stat's modifier value |
| `ScaleStatCollection(int level)` | Scales all stats in the collection to the target level |
| `ScaleStat(StatType target, int level)` | Scales the target stat in the collection to the target level |

### Protected Virtual Functions

| Name | Description |
| :--- | :---------- |
| `ConfigureStats` | Called when the stat collection is initialized, this creates all the stats and adds it to the stat dictionary. |

## Inherited Members

### Public Functions

| Name | Description |
| :--- | :---------- |
| `ToString` | Returns a string with each stat's name and value that's in the stat collection |

[1]:https://docs.unity3d.com/ScriptReference/MonoBehaviour.html