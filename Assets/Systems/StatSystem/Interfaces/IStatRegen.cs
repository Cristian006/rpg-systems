using UnityEngine;
using System.Collections;

namespace Systems.StatSystem
{
    public interface IStatRegen
    {
        int SecondsPerPoint { get; set; }

        float RegenAmount { get; }

        float TimeForNextRegen { get; set; }

        void Regenerate();
    }
}