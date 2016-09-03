using UnityEngine;
using System;
namespace Systems.StatSystem
{
    public interface IStatValueChanged
    {
        event EventHandler OnValueChanged;
    }
}
