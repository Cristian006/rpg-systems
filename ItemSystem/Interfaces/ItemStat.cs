using UnityEngine;
using System.Collections;
using Systems.StatSystem;

namespace Systems.ItemSystem
{
    public interface ItemStat
    {
        StatType StatToEffect { get; set; }
    }
}