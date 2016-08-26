using UnityEngine;
using System.Collections;
using Systems.StatSystem;

public class LevelTesting : MonoBehaviour
{
    public Entity entity;

    void Start()
    {
        InvokeRepeating("removeHealth", 1f, 5f);
        InvokeRepeating("changeLevel", 1f, 2f);
        InvokeRepeating("removeFromLevel", 2f, 3f);
    }

    void FixedUpdate()
    {
        
    }

    void removeFromLevel()
    {
        entity.level.ModifyExp(-100);
    }

    void changeLevel()
    {
        entity.level.ModifyExp(100);
    }

    void removeHealth()
    {
        entity.stats.GetStat<StatVital>(StatType.Health).StatCurrentValue -= (int)Random.Range(1, 5);
    }
}