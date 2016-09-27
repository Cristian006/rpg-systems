using UnityEngine;
using System;
using System.Collections;

public abstract class EntityLevel : MonoBehaviour {
    [SerializeField]
    private int _level = 0;

    [SerializeField]
    private int _levelMin = 0;

    [SerializeField]
    private int _levelMax = 100;

    private int _expCurrent = 0;
    private int _expRequired = 0;

    public event EventHandler<ExpGainEventArgs> OnEntityExpGain;
    public event EventHandler<LevelChangeEventArgs> OnEntityLevelChange;
    public event EventHandler<LevelChangeEventArgs> OnEntityLevelUp;
    public event EventHandler<LevelChangeEventArgs> OnEntityLevelDown;

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public int LevelMin
    {
        get { return _levelMin; }
        set { _levelMin = value; }
    }

    public int LevelMax
    {
        get { return _levelMax; }
        set { _levelMax = value; }
    }

    public int ExpCurrent
    {
        get { return _expCurrent; }
        private set { _expCurrent = value; }
    }

    public int ExpRequired
    {
        get { return _expRequired; }
        private set { _expRequired = value; }
    }

    public abstract int GetExpRequiredForLevel(int level);

    void Awake()
    {
        ExpRequired = GetExpRequiredForLevel(Level);
    }

    public void ModifyExp(int amount)
    {
        ExpCurrent += amount;

        if(OnEntityExpGain != null)
        {
            OnEntityExpGain(this, new ExpGainEventArgs(amount));
        }

        CheckCurrentExp();
    }

    public void SetCurrentExp(int value)
    {
        int expGained = value - ExpCurrent;

        ExpCurrent = value;

        if(OnEntityExpGain != null)
        {
            OnEntityExpGain(this, new ExpGainEventArgs(expGained));
        }

        CheckCurrentExp();
    }

    public void CheckCurrentExp()
    {
        int oldLevel = Level;

        InternalCheckCurrentExp();

        if(oldLevel != Level && OnEntityLevelChange != null)
        {
            OnEntityLevelChange(this, new LevelChangeEventArgs(Level, oldLevel));
        }
    }

    private void InternalCheckCurrentExp()
    {
        while (true)
        {
            if (ExpCurrent > ExpRequired)
            {
                ExpCurrent -= ExpRequired;
                InternalIncreaseCurrentLevel();
            }
            else if (ExpCurrent < 0)
            {
                ExpCurrent += GetExpRequiredForLevel(Level - 1);
                InternalDecreaseCurrentLevel();
            }
            else {
                break;
            }
        }
    }

    public void IncreaseCurrentLevel()
    {
        int oldLevel = Level;

        InternalIncreaseCurrentLevel();

        if(oldLevel != Level && OnEntityLevelChange != null)
        {
            OnEntityLevelChange(this, new LevelChangeEventArgs(Level, oldLevel));
        }
    }
    public void DecreaseCurrentLevel()
    {
        int oldLevel = Level;
        InternalDecreaseCurrentLevel();
        if (oldLevel != Level && OnEntityLevelChange != null)
        {
            OnEntityLevelChange(this, new LevelChangeEventArgs(Level, oldLevel));
        }
    }

    private void InternalIncreaseCurrentLevel()
    {
        int oldLevel = Level++;
        
        if (Level > LevelMax)
        {
            Level = LevelMax;
            ExpCurrent = GetExpRequiredForLevel(Level);
        }


        ExpRequired = GetExpRequiredForLevel(Level);
        if(oldLevel != Level && OnEntityLevelUp != null)
        {
            OnEntityLevelUp(this, new LevelChangeEventArgs(Level, oldLevel));
        }

    }

    private void InternalDecreaseCurrentLevel()
    {
        int oldLevel = Level--;
        if(Level< LevelMin)
        {
            Level = LevelMin;
            ExpCurrent = 0;
        }
        

        ExpRequired = GetExpRequiredForLevel(Level);
        if (oldLevel != Level && OnEntityLevelDown != null)
        {
            OnEntityLevelDown(this, new LevelChangeEventArgs(Level, oldLevel));
        }
    }

    public void SetLevel(int targetLevel)
    {
        SetLevel(targetLevel, true);
    }

    public void SetLevel(int targetLevel, bool clearExp)
    {
        int oldLevel = Level;
        Level = targetLevel;
        ExpRequired = GetExpRequiredForLevel(Level);

        if (clearExp)
        {
            SetCurrentExp(0);
        }
        else
        {
            InternalCheckCurrentExp();
        }


        if (oldLevel != Level && OnEntityLevelChange != null)
        {
            OnEntityLevelChange(this, new LevelChangeEventArgs(Level, oldLevel));
        }
    }
}
