using UnityEngine;
using UnityEngine.UI;
using System;
using Systems.StatSystem;

[Serializable]
public struct StatBar
{
    public Text text;
    public Slider bar;
}

[Serializable]
public struct AttrBar
{
    public Text text;
    public Slider bar;
    public Button add;
    public Button subtract;
}

public class UI : MonoBehaviour {
    [Header("ENTITY", order = 0)]
    public Entity entity;

    [Header("STATS", order = 1)]
    public StatBar health;
    public StatBar magic;
    public StatBar mana;
    public StatBar armor;
    public StatBar speed;
    public StatBar invent;
    public StatBar exp;

    [Header("ATTRIBUTES", order = 2)]
    public AttrBar stamina;
    public AttrBar strength;
    public AttrBar endurance;
    public AttrBar agility;
    public AttrBar intell;

    public Text statInfo;

    void Start()
    {
        //Adding ourselves to the callbacks
        entity.level.OnEntityExpGain += OnExpGain;
        entity.level.OnEntityLevelChange += OnLevelGain;
        entity.stats.GetStat<StatRegen>(StatType.Health).OnCurrentValueChanged += OnHealthChange;
        entity.stats.GetStat<StatVital>(StatType.Magic).OnCurrentValueChanged += OnMagicChange;
        entity.stats.GetStat<StatVital>(StatType.Mana).OnCurrentValueChanged += OnManaChange;
        entity.stats.GetStat<StatVital>(StatType.Armor).OnCurrentValueChanged += OnArmorChange;
        entity.stats.GetStat<StatVital>(StatType.Speed).OnValueChanged += OnSpeedChange;
        entity.stats.GetStat<StatVital>(StatType.InventoryCap).OnValueChanged += OnInventoryCapChange;
        entity.stats.GetStat<StatVital>(StatType.InventoryCap).OnCurrentValueChanged += OnInventoryCapChange;

        entity.stats.GetStat<StatAttribute>(StatType.Stamina).OnValueChanged += OnAttribChange;
        entity.stats.GetStat<StatAttribute>(StatType.Strength).OnValueChanged += OnAttribChange;
        entity.stats.GetStat<StatAttribute>(StatType.Intellegence).OnValueChanged += OnAttribChange;
        entity.stats.GetStat<StatAttribute>(StatType.Endurance).OnValueChanged += OnAttribChange;
        entity.stats.GetStat<StatAttribute>(StatType.Agility).OnValueChanged += OnAttribChange;

        UpdateStats();
        UpdateAttribs();
        UpdateInfo();
    }

    private void UpdateStats()
    {
        //setting the bars default values
        exp.bar.maxValue = entity.level.ExpRequired;
        exp.bar.value = entity.level.ExpCurrent;
        health.bar.maxValue = entity.stats.GetStat<StatRegen>(StatType.Health).StatValue;
        health.bar.value = entity.stats.GetStat<StatRegen>(StatType.Health).StatCurrentValue;
        invent.bar.maxValue = entity.stats.GetStat<StatVital>(StatType.InventoryCap).StatValue;
        invent.bar.value = entity.stats.GetStat<StatVital>(StatType.InventoryCap).StatCurrentValue;
        magic.bar.maxValue = entity.stats.GetStat<StatVital>(StatType.Magic).StatValue;
        magic.bar.value = entity.stats.GetStat<StatVital>(StatType.Magic).StatCurrentValue;
        armor.bar.maxValue = entity.stats.GetStat<StatVital>(StatType.Armor).StatValue;
        armor.bar.value = entity.stats.GetStat<StatVital>(StatType.Armor).StatCurrentValue;
        mana.bar.maxValue = entity.stats.GetStat<StatVital>(StatType.Mana).StatValue;
        mana.bar.value = entity.stats.GetStat<StatVital>(StatType.Mana).StatCurrentValue;
        speed.bar.maxValue = entity.stats.GetStat<StatVital>(StatType.Speed).StatValue;
        speed.bar.value = entity.stats.GetStat<StatVital>(StatType.Speed).StatCurrentValue;

        //settign the bars default text
        exp.text.text = string.Format("{0} / {1} (Level {2})",
            entity.level.ExpCurrent,
            entity.level.ExpRequired,
            entity.level.Level);
        health.text.text = string.Format("HP {0} / {1}",
            entity.stats.GetStat<StatRegen>(StatType.Health).StatCurrentValue,
            entity.stats.GetStat<StatRegen>(StatType.Health).StatValue);
        invent.text.text = string.Format("INVN {0} / {1}",
            entity.stats.GetStat<StatVital>(StatType.InventoryCap).StatCurrentValue,
            entity.stats.GetStat<StatVital>(StatType.InventoryCap).StatValue);
        magic.text.text = string.Format("MAGC {0} / {1}",
            entity.stats.GetStat<StatVital>(StatType.Magic).StatCurrentValue,
            entity.stats.GetStat<StatVital>(StatType.Magic).StatValue);
        mana.text.text = string.Format("MANA {0} / {1}",
              entity.stats.GetStat<StatVital>(StatType.Mana).StatCurrentValue,
              entity.stats.GetStat<StatVital>(StatType.Mana).StatValue);
        armor.text.text = string.Format("ARMR {0} / {1}",
            entity.stats.GetStat<StatVital>(StatType.Armor).StatCurrentValue,
            entity.stats.GetStat<StatVital>(StatType.Armor).StatValue);
        speed.text.text = string.Format("SPED {0} / {1}",
            entity.stats.GetStat<StatVital>(StatType.Speed).StatCurrentValue,
            entity.stats.GetStat<StatVital>(StatType.Speed).StatValue);

    }

    private void UpdateAttribs()
    {
        //ATTRIBUTES
        stamina.text.text = string.Format("STMNA {0} / {1} / {2}",
                    entity.stats.GetStat<StatAttribute>(StatType.Stamina).StatValue,
                    entity.stats.GetStat<StatAttribute>(StatType.Stamina).StatBaseValue,
                    entity.stats.GetStat<StatAttribute>(StatType.Stamina).StatLevelValue);

        strength.text.text = string.Format("STRNGTH {0} / {1} / {2}",
                    entity.stats.GetStat<StatAttribute>(StatType.Strength).StatValue,
                    entity.stats.GetStat<StatAttribute>(StatType.Strength).StatBaseValue,
                    entity.stats.GetStat<StatAttribute>(StatType.Strength).StatBaseValue);

        endurance.text.text = string.Format("ENDR {0} / {1} / {2}",
                    entity.stats.GetStat<StatAttribute>(StatType.Endurance).StatValue,
                    entity.stats.GetStat<StatAttribute>(StatType.Endurance).StatBaseValue,
                    entity.stats.GetStat<StatAttribute>(StatType.Endurance).StatBaseValue);

        agility.text.text = string.Format("AGIL {0} / {1} / {2}",
                    entity.stats.GetStat<StatAttribute>(StatType.Agility).StatValue,
                    entity.stats.GetStat<StatAttribute>(StatType.Agility).StatBaseValue,
                    entity.stats.GetStat<StatAttribute>(StatType.Agility).StatBaseValue);

        intell.text.text = string.Format("INTL {0} / {1} / {2}",
                    entity.stats.GetStat<StatAttribute>(StatType.Intellegence).StatValue,
                    entity.stats.GetStat<StatAttribute>(StatType.Intellegence).StatBaseValue,
                    entity.stats.GetStat<StatAttribute>(StatType.Intellegence).StatBaseValue);
    }

    void UpdateInfo()
    {
        string b = "";
        foreach (var i in entity.stats.StatDict.Keys)
        {
            if (entity.stats.ContainsStat(i))
            {
                var s = entity.stats.GetStat<StatRegen>(i);
                if(s != null)
                {
                    b += string.Format("<b>{0}</b>\nRegen Amount: {1:F}+ per sec.\nMaxValue: {2}\nBase Value: {3}\nCurrent Value: {4}\nLevel Value: {5}\nLinker Value: {6}\nEffected By:",
                        s.StatName, s.RegenAmount, s.StatValue, s.StatBaseValue, s.StatCurrentValue, s.StatLevelValue, s.StatLinkerValue);

                    for(int z = 0; z < s.StatLinkers.Count; z++)
                    {
                        StatLinkerBasic m = (StatLinkerBasic)s.StatLinkers[z];
                        b += (m.Ratio > 0 ? "+" : "-") + (m.StatThatsLinking.StatName + (z == s.StatLinkers.Count-1 ? "" : ", "));
                    }
                }
                else
                {
                    var j = entity.stats.GetStat<StatVital>(i);
                    if (j != null)
                    {
                        b += string.Format("<b>{0}</b>\nMaxValue: {1}\nBase Value: {2}\nCurrent Value: {3}\nLinker Value: {4}\nEffected By: ", j.StatName, j.StatValue, j.StatBaseValue, j.StatCurrentValue, j.StatLinkerValue);
                        for (int z = 0; z < j.StatLinkers.Count; z++)
                        {
                            StatLinkerBasic m = (StatLinkerBasic)j.StatLinkers[z];
                            b += (m.Ratio > 0 ? "+" : "-") + (m.StatThatsLinking.StatName + (z == j.StatLinkers.Count - 1 ? "" : ", "));
                        }
                    }
                    else
                    {
                        var k = entity.stats.GetStat<StatAttribute>(i);
                        if (k != null)
                        {
                            b += string.Format("<b>{0}</b>\nValue: {1}\nBase Value: {2}\nEffected By: ", k.StatName, k.StatValue, k.StatBaseValue);
                            for (int z = 0; z < k.StatLinkers.Count; z++)
                            {
                                StatLinkerBasic m = (StatLinkerBasic)k.StatLinkers[z];
                                b += (m.Ratio > 0 ? "+" : "-") + (m.StatThatsLinking.StatName + (z == k.StatLinkers.Count - 1 ? "" : ", "));
                            }
                        }
                    }
                }
                
                b += "\n";
            }
        }
        statInfo.text = b;
    }

    private void OnAttribChange(object sender, EventArgs e)
    {
        UpdateAttribs();
        UpdateInfo();
        UpdateStats();
    }

    private void OnInventoryCapChange(object sender, EventArgs e)
    {
        var i = entity.stats.GetStat<StatVital>(StatType.InventoryCap);
        invent.bar.maxValue = i.StatValue;
        invent.bar.value = i.StatCurrentValue;
        invent.text.text = string.Format("INV {0} / {1}",
            i.StatCurrentValue,
            i.StatValue);
    }

    private void OnSpeedChange(object sender, EventArgs e)
    {
        var s = entity.stats.GetStat<StatVital>(StatType.Speed);
        speed.bar.maxValue = s.StatValue;
        speed.bar.value = s.StatCurrentValue;
        speed.text.text = string.Format("SPEED {0} / {1}",
            s.StatCurrentValue,
            s.StatValue);
    }

    private void OnArmorChange(object sender, EventArgs e)
    {
        var a = entity.stats.GetStat<StatVital>(StatType.Armor);
        armor.bar.maxValue = a.StatValue;
        armor.bar.value = a.StatCurrentValue;
        armor.text.text = string.Format("ARMOR {0} / {1}",
            a.StatCurrentValue,
            a.StatValue);
    }

    private void OnManaChange(object sender, EventArgs e)
    {
        var m = entity.stats.GetStat<StatVital>(StatType.Mana);
        mana.bar.maxValue = m.StatValue;
        mana.bar.value = m.StatCurrentValue;
        mana.text.text = string.Format("MANA {0} / {1}",
            m.StatCurrentValue,
            m.StatValue);
    }

    private void OnMagicChange(object sender, EventArgs e)
    {
        var m = entity.stats.GetStat<StatVital>(StatType.Magic);
        magic.bar.maxValue = m.StatValue;
        magic.bar.value = m.StatCurrentValue;
        magic.text.text = string.Format("MAGIC {0} / {1}",
            m.StatCurrentValue,
            m.StatValue);
    }

    void OnLevelGain(object sender, LevelChangeEventArgs args)
    {
        exp.bar.maxValue = entity.level.ExpRequired;
        exp.bar.value = entity.level.ExpCurrent;
        exp.text.text = string.Format("EXP {0} / {1} (LVL {2})",
            entity.level.ExpCurrent,
            entity.level.ExpRequired,
            args.NewLevel);
    }

    void OnExpGain(object sender, ExpGainEventArgs args)
    {
        exp.bar.maxValue = entity.level.ExpRequired;
        exp.bar.value = entity.level.ExpCurrent;
        exp.text.text = string.Format("EXP {0} / {1} (LVL {2})",
            entity.level.ExpCurrent,
            entity.level.ExpRequired,
            entity.level.Level);
    }

    void OnHealthChange(object sender, EventArgs args)
    {
        var h = entity.stats.GetStat<StatRegen>(StatType.Health);
        health.bar.maxValue = h.StatValue;
        health.bar.value = h.StatCurrentValue;
        health.text.text = string.Format("HP {0} / {1}",
            h.StatCurrentValue,
            h.StatValue);
    }
}
