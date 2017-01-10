using UnityEngine;
using UnityEngine.UI;
using System;
using Systems.StatSystem;
using Systems.EntitySystem;

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

public class StatSystemUI : MonoBehaviour {
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
        entity.Level.OnEntityExpGain += OnExpGain;
        entity.Level.OnEntityLevelChange += OnLevelGain;
        entity.Stats.GetStat<StatRegeneratable>(StatType.Health).OnCurrentValueChanged += OnHealthChange;
        entity.Stats.GetStat<StatVital>(StatType.Magic).OnCurrentValueChanged += OnMagicChange;
        entity.Stats.GetStat<StatVital>(StatType.Mana).OnCurrentValueChanged += OnManaChange;
        entity.Stats.GetStat<StatVital>(StatType.Armor).OnCurrentValueChanged += OnArmorChange;
        entity.Stats.GetStat<StatVital>(StatType.Speed).OnValueChanged += OnSpeedChange;
        entity.Stats.GetStat<StatVital>(StatType.InventoryCap).OnValueChanged += OnInventoryCapChange;
        entity.Stats.GetStat<StatVital>(StatType.InventoryCap).OnCurrentValueChanged += OnInventoryCapChange;

        entity.Stats.GetStat<StatAttribute>(StatType.Stamina).OnValueChanged += OnAttribChange;
        entity.Stats.GetStat<StatAttribute>(StatType.Strength).OnValueChanged += OnAttribChange;
        entity.Stats.GetStat<StatAttribute>(StatType.Intellegence).OnValueChanged += OnAttribChange;
        entity.Stats.GetStat<StatAttribute>(StatType.Endurance).OnValueChanged += OnAttribChange;
        entity.Stats.GetStat<StatAttribute>(StatType.Agility).OnValueChanged += OnAttribChange;

        UpdateStats();
        UpdateAttribs();
        UpdateInfo();
    }

    private void UpdateStats()
    {
        //setting the bars default values
        exp.bar.maxValue = entity.Level.ExpRequired;
        exp.bar.value = entity.Level.ExpCurrent;
        health.bar.maxValue = entity.Stats.GetStat<StatRegeneratable>(StatType.Health).Max;
        health.bar.value = entity.Stats.GetStat<StatRegeneratable>(StatType.Health).Value;
        invent.bar.maxValue = entity.Stats.GetStat<StatVital>(StatType.InventoryCap).Max;
        invent.bar.value = entity.Stats.GetStat<StatVital>(StatType.InventoryCap).Value;
        magic.bar.maxValue = entity.Stats.GetStat<StatVital>(StatType.Magic).Max;
        magic.bar.value = entity.Stats.GetStat<StatVital>(StatType.Magic).Value;
        armor.bar.maxValue = entity.Stats.GetStat<StatVital>(StatType.Armor).Max;
        armor.bar.value = entity.Stats.GetStat<StatVital>(StatType.Armor).Value;
        mana.bar.maxValue = entity.Stats.GetStat<StatVital>(StatType.Mana).Max;
        mana.bar.value = entity.Stats.GetStat<StatVital>(StatType.Mana).Value;
        speed.bar.maxValue = entity.Stats.GetStat<StatVital>(StatType.Speed).Max;
        speed.bar.value = entity.Stats.GetStat<StatVital>(StatType.Speed).Value;

        //settign the bars default text
        exp.text.text = string.Format("{0} / {1} (Level {2})",
            entity.Level.ExpCurrent,
            entity.Level.ExpRequired,
            entity.Level.Level);
        health.text.text = string.Format("HP {0} / {1}",
            entity.Stats.GetStat<StatRegeneratable>(StatType.Health).Value,
            entity.Stats.GetStat<StatRegeneratable>(StatType.Health).Max);
        invent.text.text = string.Format("INVN {0} / {1}",
            entity.Stats.GetStat<StatVital>(StatType.InventoryCap).Value,
            entity.Stats.GetStat<StatVital>(StatType.InventoryCap).Max);
        magic.text.text = string.Format("MAGC {0} / {1}",
            entity.Stats.GetStat<StatVital>(StatType.Magic).Value,
            entity.Stats.GetStat<StatVital>(StatType.Magic).Max);
        mana.text.text = string.Format("MANA {0} / {1}",
              entity.Stats.GetStat<StatVital>(StatType.Mana).Value,
              entity.Stats.GetStat<StatVital>(StatType.Mana).Max);
        armor.text.text = string.Format("ARMR {0} / {1}",
            entity.Stats.GetStat<StatVital>(StatType.Armor).Value,
            entity.Stats.GetStat<StatVital>(StatType.Armor).Max);
        speed.text.text = string.Format("SPED {0} / {1}",
            entity.Stats.GetStat<StatVital>(StatType.Speed).Value,
            entity.Stats.GetStat<StatVital>(StatType.Speed).Max);

    }

    private void UpdateAttribs()
    {
        //ATTRIBUTES
        stamina.text.text = string.Format("STMNA {0} / {1} / {2}",
                    entity.Stats.GetStat<StatAttribute>(StatType.Stamina).Value,
                    entity.Stats.GetStat<StatAttribute>(StatType.Stamina).Base,
                    entity.Stats.GetStat<StatAttribute>(StatType.Stamina).LevelValue);

        strength.text.text = string.Format("STRNGTH {0} / {1} / {2}",
                    entity.Stats.GetStat<StatAttribute>(StatType.Strength).Value,
                    entity.Stats.GetStat<StatAttribute>(StatType.Strength).Base,
                    entity.Stats.GetStat<StatAttribute>(StatType.Strength).Base);

        endurance.text.text = string.Format("ENDR {0} / {1} / {2}",
                    entity.Stats.GetStat<StatAttribute>(StatType.Endurance).Value,
                    entity.Stats.GetStat<StatAttribute>(StatType.Endurance).Base,
                    entity.Stats.GetStat<StatAttribute>(StatType.Endurance).Base);

        agility.text.text = string.Format("AGIL {0} / {1} / {2}",
                    entity.Stats.GetStat<StatAttribute>(StatType.Agility).Value,
                    entity.Stats.GetStat<StatAttribute>(StatType.Agility).Base,
                    entity.Stats.GetStat<StatAttribute>(StatType.Agility).Base);

        intell.text.text = string.Format("INTL {0} / {1} / {2}",
                    entity.Stats.GetStat<StatAttribute>(StatType.Intellegence).Value,
                    entity.Stats.GetStat<StatAttribute>(StatType.Intellegence).Base,
                    entity.Stats.GetStat<StatAttribute>(StatType.Intellegence).Base);
    }

    void UpdateInfo()
    {
        string b = "";
        foreach (var i in entity.Stats.StatDict.Keys)
        {
            if (entity.Stats.ContainsStat(i))
            {
                var s = entity.Stats.GetStat<StatRegeneratable>(i);
                if(s != null)
                {
                    b += string.Format("<b>{0}</b>\nRegen Amount: {1:F}+ per sec.\nMaxValue: {2}\nBase Value: {3}\nCurrent Value: {4}\nLevel Value: {5}\nLinker Value: {6}\nEffected By:",
                        s.Name, s.RegenAmount, s.Max, s.Base, s.Value, s.LevelValue, s.LinkerValue);

                    for(int z = 0; z < s.Linkers.Count; z++)
                    {
                        ExampleStatLinker m = (ExampleStatLinker)s.Linkers[z];
                        b += (m.Ratio > 0 ? "+" : "-") + (m.StatThatsLinking.Name + (z == s.Linkers.Count-1 ? "" : ", "));
                    }
                }
                else
                {
                    var j = entity.Stats.GetStat<StatVital>(i);
                    if (j != null)
                    {
                        b += string.Format("<b>{0}</b>\nMaxValue: {1}\nBase Value: {2}\nCurrent Value: {3}\nLinker Value: {4}\nEffected By: ", j.Name, j.Max, j.Base, j.Value, j.LinkerValue);
                        for (int z = 0; z < j.Linkers.Count; z++)
                        {
                            ExampleStatLinker m = (ExampleStatLinker)j.Linkers[z];
                            b += (m.Ratio > 0 ? "+" : "-") + (m.StatThatsLinking.Name + (z == j.Linkers.Count - 1 ? "" : ", "));
                        }
                    }
                    else
                    {
                        var k = entity.Stats.GetStat<StatAttribute>(i);
                        if (k != null)
                        {
                            b += string.Format("<b>{0}</b>\nValue: {1}\nBase Value: {2}\nEffected By: ", k.Name, k.Value, k.Base);
                            for (int z = 0; z < k.Linkers.Count; z++)
                            {
                                ExampleStatLinker m = (ExampleStatLinker)k.Linkers[z];
                                b += (m.Ratio > 0 ? "+" : "-") + (m.StatThatsLinking.Name + (z == k.Linkers.Count - 1 ? "" : ", "));
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
        var i = entity.Stats.GetStat<StatVital>(StatType.InventoryCap);
        invent.bar.maxValue = i.Max;
        invent.bar.value = i.Value;
        invent.text.text = string.Format("INV {0} / {1}",
            i.Value,
            i.Max);
    }

    private void OnSpeedChange(object sender, EventArgs e)
    {
        var s = entity.Stats.GetStat<StatVital>(StatType.Speed);
        speed.bar.maxValue = s.Max;
        speed.bar.value = s.Value;
        speed.text.text = string.Format("SPEED {0} / {1}",
            s.Value,
            s.Max);
    }

    private void OnArmorChange(object sender, EventArgs e)
    {
        var a = entity.Stats.GetStat<StatVital>(StatType.Armor);
        armor.bar.maxValue = a.Max;
        armor.bar.value = a.Value;
        armor.text.text = string.Format("ARMOR {0} / {1}",
            a.Value,
            a.Max);
    }

    private void OnManaChange(object sender, EventArgs e)
    {
        var m = entity.Stats.GetStat<StatVital>(StatType.Mana);
        mana.bar.maxValue = m.Max;
        mana.bar.value = m.Value;
        mana.text.text = string.Format("MANA {0} / {1}",
            m.Value,
            m.Max);
    }

    private void OnMagicChange(object sender, EventArgs e)
    {
        var m = entity.Stats.GetStat<StatVital>(StatType.Magic);
        magic.bar.maxValue = m.Max;
        magic.bar.value = m.Value;
        magic.text.text = string.Format("MAGIC {0} / {1}",
            m.Value,
            m.Max);
    }

    void OnLevelGain(object sender, LevelChangeEventArgs args)
    {
        exp.bar.maxValue = entity.Level.ExpRequired;
        exp.bar.value = entity.Level.ExpCurrent;
        exp.text.text = string.Format("EXP {0} / {1} (LVL {2})",
            entity.Level.ExpCurrent,
            entity.Level.ExpRequired,
            args.NewLevel);
    }

    void OnExpGain(object sender, ExpGainEventArgs args)
    {
        exp.bar.maxValue = entity.Level.ExpRequired;
        exp.bar.value = entity.Level.ExpCurrent;
        exp.text.text = string.Format("EXP {0} / {1} (LVL {2})",
            entity.Level.ExpCurrent,
            entity.Level.ExpRequired,
            entity.Level.Level);
    }

    void OnHealthChange(object sender, EventArgs args)
    {
        var h = entity.Stats.GetStat<StatRegeneratable>(StatType.Health);
        health.bar.maxValue = h.Max;
        health.bar.value = h.Value;
        health.text.text = string.Format("HP {0} / {1}",
            h.Value,
            h.Max);
    }
}
