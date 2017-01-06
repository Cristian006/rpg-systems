using UnityEngine;
using System;
using System.Collections;

public class LevelChangeEventArgs : EventArgs {
    public int NewLevel { get; private set; }
    public int OldLevel { get; private set; }

    public LevelChangeEventArgs(int newLevel, int oldLevel)
    {
        NewLevel = newLevel;
        OldLevel = oldLevel;
    }
}
