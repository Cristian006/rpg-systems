using UnityEngine;
using System.Collections;
using Systems.StatSystem;


public class Testing : MonoBehaviour
{
    public Entity entity;

    public void AddToAttribute(int id)
    {
        StatType s = (StatType)id;
        entity.stats.GetStat<StatAttribute>(s).ScaleStatToNextLevel();
    }

    public void SubtractFromAttribute(int id)
    {
        Debug.Log(id);
        StatType s = (StatType)id;
        entity.stats.GetStat<StatAttribute>(s).ScaleStatToPrevLevel();
    }

    public void TakeDamage()
    {
        entity.TakeDamage(Random.Range(5, 20));
    }

    public void ReceiveHealth()
    {
        entity.RestoreHealth(Random.Range(5, 20));
    }

    public void RestoreHealth()
    {
        entity.RestoreHealth();
    }

    public void AddInventory()
    {
        entity.stats.GetStat<StatVital>(StatType.InventoryCap).StatCurrentValue += Random.Range(1, 5);
    }

    public void RemoveFromInventory()
    {
        entity.stats.GetStat<StatVital>(StatType.InventoryCap).StatCurrentValue -= Random.Range(1, 5);
    }

    public void ReceiveExp()
    {
        entity.level.ModifyExp(Random.Range(75,100));
    }

    public void RemoveExp()
    {
        entity.level.ModifyExp(Random.Range(-100, -50));
    }

    public void UseMagic()
    {
        entity.stats.GetStat<StatVital>(StatType.Magic).StatCurrentValue -= Random.Range(10, 15);
    }

    public void AddModifier()
    {
        entity.stats.GetStat<StatRegen>(StatType.Health).AddModifier(new StatModBasePercent(1f, false));
        entity.stats.GetStat<StatRegen>(StatType.Health).AddModifier(new StatModBaseAdd(50f));
        entity.stats.GetStat<StatRegen>(StatType.Health).AddModifier(new StatModBaseAdd(1.0f));
        entity.stats.GetStat<StatRegen>(StatType.Health).UpdateModifiers();
    }
}