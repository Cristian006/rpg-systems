# Stat System

namespace `Systems.StatSystem`

## Description

This system handles what makes up a working stat collection in game for any object needing a set of stats.

## Editor

This system comes with a Stat Type Editor Window to use with Unity.
Use the editor window to create more stat types to use in the Stat Database.

Open Editor:

- `Ctr + Shift + T`
- `Window > Systems > Stat Type Editor`

## Contents

1. [Interfaces][1]
    - All interfaces used in stat system
1. [Enumerations][27]
    - All Enumerations used in stat system
1. [Stat][2]
    - Stat and all of its extentions
1. [Stat Modifiers][3]
    - Stat Modifiers and all of its example extentions
1. [Stat Linkers][4]
    - Stat Linker and all of its extentions
1. [Stat Collections][26]
    - The Stat Container class which holds the list of stats for an entity

## Interfaces

| Class Name | Description |
| :--------- | :---------- |
| [IStatModifiable][5] | Interface for an object to accept a [`StatModifier`][3]. |
| [IStatValueChanged][6] | Interface for an object which needs an Event for other objects to subscribe to when its Value Changes. |
| [IStatCurrentValueChanged][7] | Interface for an object which needs an Event for other objects to subscribe to when its Current Value Changes. |
| [IStatLinkable][8] | Interface for an object to accept a [`StatLinker`][4]. |
| [IStatScalable][9] | Interface for an object that needs to scale itself based on an `int` value; in this case, a Stat's Level. |
| [IStatRegeneratable][10] | Interface for an object that will have the added ability to regenerate a point value over time. |

## Enumerations

| Name | Description |
| :--- | :---------- |
| [StatType][23] | Enum that holds all of the different stat types available in this Stat System |

## Stat

| Class Name | Description |
| :--------- | :---------- |
| [Stat][11] | Base Stat Class |
| [StatModifiable][12] | Adds Stat Modifications |
| [StatAttribute][13] | Adds Stat Linking and Stat Scaling |
| [StatVital][14] | Adds a Current Value variable to the stat |
| [StatRegen][15] | Adds regeneration ability to Stat |

## Stat Modifiers

| Class Name | Description |
| :--------- | :---------- |
| [StatModifier][16] | Base Stat Modification Class |
| [StatModBaseAdd][17] | Adds the Mod Value to the Base Value of the stat with an Order of 2. |
| [StatModBasePercent][18] | Adds a Percentage of the Base Stat Value back to the stat with an Order of 1. |
| [StatModTotalAdd][19] | Adds the Mod Value to the Total Stat Value of the stat with an Order of 4. |
| [StatModTotalPercent][20] | Adds a Percentage of the Total Stat Value back to the stat with an Order of 3. |

## Stat Linkers

| Class Name | Description |
| :--------- | :---------- |
| [StatLinker][21] | Links one Stat to another Attribute. Base Stat Linker Class. |
| [ExampleStatLinker][22] | Links one Stat to another Attribute with a custom ratio to affect the Stat. Example Extention of the Stat Linker Class |

## Stat Collections

| Class Name | Description |
| :--------- | :---------- |
| [StatCollection][24] | Class that holds a collection of different Stats. Base Stat Collection Class. |
| [ExampleStatCollection][25] | Custom Stat Configuration, Example Extention of the Stat Collection Class |

[1]: #interfaces
[2]: #stat
[3]: #stat-modifiers
[4]: #stat-linkers
[26]: #stat-collections
[27]: #enumerations

[5]: Interfaces/IStatModifiable/IStatModifiable.md
[6]: Interfaces/IStatValueChange/IStatValueChanged.md
[7]: Interfaces/IStatValueChange/IStatCurrentValueChanged.md
[8]: Interfaces/IStatLinkable/IStatLinkable.md
[9]: Interfaces/IStatScalable/IStatScalable.md
[10]: Interfaces/IStatRegeneratable/IStatRegeneratable.md

[11]: Stats/Stat.md
[12]: Stats/Extentions/Modifiable/StatModifiable.md
[13]: Stats/Extentions/Attribute/StatAttribute,md
[14]: Stats/Extentions/Vital/StatVital.md
[15]: Stats/Extentions/Regeneratable/StatRegeneratable.md

[16]: Modifiers/StatModifier.md
[17]: Modifiers/Extentions/
[18]: Modifiers/Extentions/
[19]: Modifiers/Extentions/
[20]: Modifiers/Extentions/

[21]: Linkers/StatLinker.md
[22]: Linkers/Extentions/ExampleStatLinker.md

[23]: StatTypes/StatType.md

[24]: StatCollections/StatCollection.md
[25]: StatCollections/Extentions/ExampleStatCollection.md