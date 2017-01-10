# Stat

class in `Systems.StatSystem`

### Description

Base Class for Stat

```csharp
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
    public Stat health;
    void Example() {
        health = new Stat("Health", 100);
        //health base Value = 100
        //health stat Name = "Health"
    }
}
```

### Public Properties

| Name | Description |
| :--- | :---------- |
| `StatName` | returns the name of the stat |
| `StatBaseValue` | returns the base value of the stat |

## Inherited Members

### Public Functions

| Name | Description |
| :--- | :---------- |
| `ToString` | Returns the name of the stat and base value |