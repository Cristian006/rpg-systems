# Stat System

namespace `Systems.StatSystem`

## Description

Make description for this system cristian

## Contents

1. [Interfaces][1]
    - All interfaces used in stat system
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
| [IStatModifiable][5] |  |
| [IStatValueChanged][6] |  |
| [IStatCurrentValueChanged][7] |  |
| [IStatLinkable][8] |  |
| [IStatScalable][9] |  |
| [IStatRegeneratable][10] |  |

## Enumerations

| Name | Description |
| :--- | :---------- |
| [StatType][23] | Enum that holds all of the different stat types available |

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
| [StatModifier][16] |  |
| [StatModBaseAdd][17] |  |
| [StatModBasePercent][18] |  |
| [StatModTotalAdd][19] |  |
| [StatModTotalPercent][20] |  |

## Stat Linkers

| Class Name | Description |
| :--------- | :---------- |
| [StatLinker][21] |  |
| [StatLinkerBasic][22] |  |

## Stat Collections

| Class Name | Description |
| :--------- | :---------- |
| [StatCollection][24] |  |
| [ExampleStatCollection][25] |  |

[1]: #interfaces
[2]: #stat
[3]: #stat-modifiers
[4]: #stat-linkers
[26]: #stat-collections

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
[22]: Linkers/Extentions/StatLinkerBasic.md

[23]: StatTypes/StatType.md

[24]: StatCollections/StatCollection.md
[25]: StatCollections/Extentions/ExampleStatCollection.md