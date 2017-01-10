# StatAttribute

class in `Systems.StatSystem` / Inherits from: [StatModifiable][1] 

### Description

Added Stat Functionality: `Stat Linking with Attributes and Stat Scaling`

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
| `StatLinkerValue` | Returns total stat linking value |
| `StatLinkers` | Returns a `List` of Stat Linkers |
| `StatLevelValue` | Returns the stats current level |

### Public Functions

| Name | Description |
| :--- | :---------- |
| `AddLinker` | Adds the passed in linker to the list of Stat Linkers and updates the total stat linker value |
| `ClearLinkers` | Clears the list of stat linkers and updates the total stat linker value |
| `UpdateLinkers` | Iterates through the list of Stat Linkers and gets the total linker value |
| `ScaleStat` | |
| `ScaleStatToNextLevel` |  |
| `ScaleStatToPrevLevel` |  |

## Inherited Members

### Overrided Public Properties

| Name | Description |
| :--- | :---------- |
| `StatBaseValue` | returns the stats base value with the stat level value |

[1]: ../Modifiable/StatModifiable.md