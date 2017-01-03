using UnityEngine;
using System.Collections;
namespace Systems.StatSystem
{
    public interface IStatModifiable
    {
        int StatModifierValue { get; }      //get the modvalue
        void AddModifier(StatModifier mod);     //add mod to stat
        void RemoveModifier(StatModifier mod); //remove mod from stat
        void ClearModifiers();  //clear all mods
        void UpdateModifiers(); //update total mod value when added mods change
    }
}
