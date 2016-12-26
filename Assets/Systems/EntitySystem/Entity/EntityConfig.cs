using UnityEngine;
using System.Collections;
using Systems.StatSystem;
using System;
/// <summary>
/// This is where you link up the type of stat collection to the enum
/// for when the editor script creates all the base Character Prefabs
/// </summary>
namespace Systems.EntitySystem
{
    public static class EntityConfig
    {
        public static T GetType<T>(EntityClass ec) where T : StatCollection
        {
            switch (ec)
            {
                case EntityClass.None:
                    return (T)(new StatCollection());
                case EntityClass.Alchemist:
                    return new BaseStatCollection() as T;
                case EntityClass.Assassin:
                    return new BaseStatCollection() as T;
                case EntityClass.Barbarian:
                    return null;
                case EntityClass.Oracle:
                    return null;
                case EntityClass.Ninja:
                    return null;
                case EntityClass.Scout:
                    return null;
                case EntityClass.Sorcerer:
                    return null;
                case EntityClass.Warrior:
                    return null;
                case EntityClass.Wizard:
                    return null;
                case EntityClass.Warlord:
                    return null;
                default:
                    return new BaseStatCollection() as T;
            }
        }
    }
}

