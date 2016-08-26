using UnityEngine;
using System.Collections;

public class DefualtLevel : EntityLevel
{
    public override int GetExpRequiredForLevel(int level)
    {
        return (int)(Mathf.Pow(Level, 2f) * 100) + 100;
    }
}
