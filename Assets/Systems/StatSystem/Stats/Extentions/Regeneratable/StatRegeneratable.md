# StatRegeneratable

class in `Systems.StatSystem` / Inherits from: [StatVital][1]

### Description

Added Stat Functionality: `Stat Regeneration over time`

```csharp
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
    void Example() {
        //do Example cristian
    }
}
```

### Public Properties

| Name | Description |
| :--- | :---------- |
| `SecondsPerPoint` | |
| `BaseSecondsPerPoint` | |
| `LinkMultiplier` | |
| `MinSecondsPerPoint` | |
| `RegenAmount` | |
| `TimeForNextRegen` | |

### Public Functions

| Name | Description |
| :--- | :---------- |
| `Regenerate` | increases the stats current value by one |

## Inherited Members

### Overrided Public Functions

| Name | Description |
| :--- | :---------- |
| `UpdateLinkers` | Iterates through the list of Stat Linkers and gets the total linker value but with the added functionallity of being able to affect a secondary stat, in this case, the stat's regen amount per second |

[1]: ../Vital/StatVital.md