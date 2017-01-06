using UnityEngine;
using System.Collections;
using System;

public class ExpGainEventArgs : EventArgs {
    public int ExpGained { get; private set; }

    public ExpGainEventArgs(int expGained)
    {
        ExpGained = expGained;
    }
}
