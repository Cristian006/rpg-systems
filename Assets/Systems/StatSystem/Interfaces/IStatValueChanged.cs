using UnityEngine;
using System;
namespace Systems.StatSystem
{
    public interface IStatValueChanged
    {
        event EventHandler OnValueChanged;  //for any stat that needs to update other components when its value changes via an event trigger
    }
}
