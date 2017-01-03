# StatModifiable

class in `Systems.StatSystem` / Inherits from: [Stat][1]

### Description

Added Stat Functionality: `Temporary Stat Value Modification`

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
| `StatModifierValue` | Returns total stat modification value |

### Public Functions

| Name | Description |
| :--- | :---------- |
| `AddModifier` | Adds the passed in modifier to the list and updates the total modifier value |
| `RemoveModifier` | Removes the passed in modifier |
| `ClearModifier` | Clears the list of modifiers and updates the total modifier value |
| `UpdateModifiers` | Iterates through the list of Stat Modifiers and gets the total modifier value |

## Inherited Members

### Overrided Public Properties

| Name | Description |
| :--- | :---------- |
| `StatValue` | Returns the base value of the stat with the added stat modification value |

[1]: ../../Stat.md