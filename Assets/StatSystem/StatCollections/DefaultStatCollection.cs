using UnityEngine;
using System.Collections.Generic;
using Systems.StatSystem;

public class DefaultStatCollection : StatCollection {
    protected override void ConfigureStats()
    {
        //ATTRIBUTES
        var stamina = CreateOrGetStat<StatAttribute>(StatType.Stamina);
        stamina.StatName = "Stamina";
        stamina.StatBaseValue = 0;

        var stength = CreateOrGetStat<StatAttribute>(StatType.Strength);
        stength.StatName = "Strength";
        stength.StatBaseValue = 5;

        var endurance = CreateOrGetStat<StatAttribute>(StatType.Endurance);
        endurance.StatName = "Endurance";
        endurance.StatBaseValue = 8;

        var agility = CreateOrGetStat<StatAttribute>(StatType.Agility);
        agility.StatName = "Agility";
        agility.StatBaseValue = 8;

        var intellegence = CreateOrGetStat<StatAttribute>(StatType.Intellegence);
        intellegence.StatName = "Intellegence";
        intellegence.StatBaseValue = 0;

        //STATS
        var health = CreateOrGetStat<StatRegen>(StatType.Health);
        health.StatName = "Health";
        health.StatBaseValue = 100;
        health.BaseSecondsPerPoint = 100;
        //Stamina = 10; and our ratio is 10; 10*10 = 0; health = 100; health + Stamina = 200
        health.AddLinker(new StatLinkerBasic(CreateOrGetStat<StatAttribute>(StatType.Stamina), 10f)); // health should be 200
        //Endurance = 8; and our ratio is 1; 1*8= 8; health.SecondsPerPoint = 1; health.SecondsPerPoint - Endurance = 8
        health.AddLinker(new StatLinkerBasic(CreateOrGetStat<StatAttribute>(StatType.Endurance), 1f, true));
        health.UpdateLinkers();
        health.RestoreCurrentValueToMax();

        var magic = CreateOrGetStat<StatRegen>(StatType.Magic);
        magic.StatName = "Magic";
        magic.StatBaseValue = 10;
        magic.BaseSecondsPerPoint = 10;
        magic.RestoreCurrentValueToMax();

        var mana = CreateOrGetStat<StatRegen>(StatType.Mana);
        mana.StatName = "Mana";
        mana.StatBaseValue = 100;
        mana.BaseSecondsPerPoint = 10;
        //intellegence = 0; and our ratio is 50; 0 * 50 = 0; mana = 100; mana + 0 = 100
        mana.AddLinker(new StatLinkerBasic(CreateOrGetStat<StatAttribute>(StatType.Intellegence), 50f)); //mana should be 100
        mana.UpdateLinkers();
        mana.RestoreCurrentValueToMax();

        var armor = CreateOrGetStat<StatVital>(StatType.Armor);
        armor.StatName = "Armor";
        armor.StatBaseValue = 50;
        armor.RestoreCurrentValueToMax();

        var armorProtection = CreateOrGetStat<StatAttribute>(StatType.ArmorProtection);
        armorProtection.StatName = "ArmorProtection";
        armorProtection.StatBaseValue = 50;

        //for speed, the statValue will be it's max value, and currentspeed will equal to the max value unless it's being modified
        var speed = CreateOrGetStat<StatVital>(StatType.Speed);
        speed.StatName = "Speed";
        speed.StatBaseValue = 1;
        speed.AddLinker(new StatLinkerBasic(CreateOrGetStat<StatAttribute>(StatType.Agility), 0.01f));
        speed.RestoreCurrentValueToMax();

        var inventory = CreateOrGetStat<StatVital>(StatType.InventoryCap);
        inventory.StatName = "Inventory";
        inventory.StatBaseValue = 5;
        //strength = 5; and our ratio is 1; 5 * 1 = 5; inventory = 5; inventory + 5 = 10;
        inventory.AddLinker(new StatLinkerBasic(CreateOrGetStat<StatAttribute>(StatType.Strength), 1f)); //inventory max cap should be 5;
        inventory.UpdateLinkers();
    }

    void FixedUpdate()
    {
        RegenStats();
    }

    void RegenStats()
    {
        foreach(var i in GetAllRegeneratingStats())
        {
            if (i.StatCurrentValue != i.StatValue)
            {
                if (Time.time > i.TimeForNextRegen)
                {
                    i.Regenerate();
                    i.TimeForNextRegen = Time.time + i.SecondsPerPoint;
                }
            }
        }
    }
}