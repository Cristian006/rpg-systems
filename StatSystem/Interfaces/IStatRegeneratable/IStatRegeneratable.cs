using UnityEngine;
using System.Collections;

namespace Systems.StatSystem
{
    public interface IStatRegeneratable
    {
        int SecondsPerPoint { get; set; }

        float RegenAmount { get; }

        float TimeForNextRegen { get; set; }

        void Regenerate();
    }
}