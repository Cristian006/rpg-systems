using UnityEngine;
using System;
namespace Systems.StatSystem
{
    public interface IStatCurrentValueChanged
    {
        event EventHandler OnCurrentValueChanged;
    }
}
