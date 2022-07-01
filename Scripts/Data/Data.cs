using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#region PlayerStat
[Serializable]
public class PlayerStat
{
    public int level;
    public int hp;
    public int attack;
}

[Serializable]
public class PlayerStatData : ILoader<int, PlayerStat>
{
    public List<PlayerStat> stats = new List<PlayerStat>();

    public Dictionary<int, PlayerStat> MakeDict()
    {
        Dictionary<int, PlayerStat> dict = new Dictionary<int, PlayerStat>();

        foreach (PlayerStat stat in stats)
            dict.Add(stat.level, stat);

        return dict;
    }
}
#endregion

[Serializable]
public class MonsterStat
{
    public string name;
    public int hp;
    public int attack;
}

[Serializable]
public class MonsterStatData : ILoader<string, MonsterStat>
{
    public List<MonsterStat> monster = new List<MonsterStat>();

    public Dictionary<string, MonsterStat> MakeDict()
    {
        Dictionary<string, MonsterStat> dict = new Dictionary<string, MonsterStat>();

        foreach (MonsterStat stat in monster)
            dict.Add(stat.name, stat);

        return dict;
    }
}


[Serializable]
public class itemStat
{
    public int _No;
    public string _Name;
    public int _max_hp;
    public int _max_mp;
    public int _min_attack;
    public int _max_attack;
    public int _defence;
    public int _min_magic_attack;
    public int _max_magic_attack;
    public int _fire_res;
    public int _cold_res;
    public int _earth_res;
    public int _dark_res;
    public int _poison_res;
    public int _accuracy;
    public int _avoid;
    public int _enhance;
    public int _str_limit;
    public int _dex_limit;
    public int _int_limit;
    public int _Hand;
    public int _enhance_limit;
    public string _NickName;
}// 상속으로 넘겨줌 나머지는 구분용

[Serializable]
public class axe : itemStat { }
[Serializable]
public class axeStatData : ILoader<int, axe>
{
    public List<axe> axeData = new List<axe>();

    public Dictionary<int, axe> MakeDict()
    {
        Dictionary<int, axe> dict = new Dictionary<int, axe>();

        foreach (axe stat in axeData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class axe_randart : itemStat { }
[Serializable]
public class axe_randartStatData : ILoader<int, axe_randart>
{
    public List<axe_randart> axe_ranData = new List<axe_randart>();

    public Dictionary<int, axe_randart> MakeDict()
    {
        Dictionary<int, axe_randart> dict = new Dictionary<int, axe_randart>();

        foreach (axe_randart stat in axe_ranData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class boot : itemStat { }
[Serializable]
public class bootStatData : ILoader<int, boot>
{
    public List<boot> bootData = new List<boot>();

    public Dictionary<int, boot> MakeDict()
    {
        Dictionary<int, boot> dict = new Dictionary<int, boot>();

        foreach (boot stat in bootData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class bow : itemStat { }
[Serializable]
public class bowStatData : ILoader<int, bow>
{
    public List<bow> bowData = new List<bow>();

    public Dictionary<int, bow> MakeDict()
    {
        Dictionary<int, bow> dict = new Dictionary<int, bow>();

        foreach (bow stat in bowData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class bow_randart : itemStat { }
[Serializable]
public class bow_randartStatData : ILoader<int, bow_randart>
{
    public List<bow_randart> bow_ranData = new List<bow_randart>();

    public Dictionary<int, bow_randart> MakeDict()
    {
        Dictionary<int, bow_randart> dict = new Dictionary<int, bow_randart>();

        foreach (bow_randart stat in bow_ranData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class glove : itemStat { }
[Serializable]
public class gloveStatData : ILoader<int, glove>
{
    public List<glove> gloveData = new List<glove>();

    public Dictionary<int, glove> MakeDict()
    {
        Dictionary<int, glove> dict = new Dictionary<int, glove>();

        foreach (glove stat in gloveData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class helmet : itemStat { }
[Serializable]
public class helmetStatData : ILoader<int, helmet>
{
    public List<helmet> helmetData = new List<helmet>();

    public Dictionary<int, helmet> MakeDict()
    {
        Dictionary<int, helmet> dict = new Dictionary<int, helmet>();

        foreach (helmet stat in helmetData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class helmet_randart : itemStat { }
[Serializable]
public class helmet_randartStatData : ILoader<int, helmet_randart>
{
    public List<helmet_randart> helmet_randartData = new List<helmet_randart>();

    public Dictionary<int, helmet_randart> MakeDict()
    {
        Dictionary<int, helmet_randart> dict = new Dictionary<int, helmet_randart>();

        foreach (helmet_randart stat in helmet_randartData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class mace : itemStat { }
[Serializable]
public class maceStatData : ILoader<int, mace>
{
    public List<mace> maceData = new List<mace>();

    public Dictionary<int, mace> MakeDict()
    {
        Dictionary<int, mace> dict = new Dictionary<int, mace>();

        foreach (mace stat in maceData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class mace_randart : itemStat { }
[Serializable]
public class mace_randartStatData : ILoader<int, mace_randart>
{
    public List<mace_randart> mace_randartData = new List<mace_randart>();

    public Dictionary<int, mace_randart> MakeDict()
    {
        Dictionary<int, mace_randart> dict = new Dictionary<int, mace_randart>();

        foreach (mace_randart stat in mace_randartData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class ring : itemStat { }
[Serializable]
public class ringStatData : ILoader<int, ring>
{
    public List<ring> ringData = new List<ring>();

    public Dictionary<int, ring> MakeDict()
    {
        Dictionary<int, ring> dict = new Dictionary<int, ring>();

        foreach (ring stat in ringData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class ring_randart : itemStat { }
[Serializable]
public class ring_randartStatData : ILoader<int, ring_randart>
{
    public List<ring_randart> ring_randartData = new List<ring_randart>();

    public Dictionary<int, ring_randart> MakeDict()
    {
        Dictionary<int, ring_randart> dict = new Dictionary<int, ring_randart>();

        foreach (ring_randart stat in ring_randartData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class robe : itemStat { }
[Serializable]
public class robeStatData : ILoader<int, robe>
{
    public List<robe> robeData = new List<robe>();

    public Dictionary<int, robe> MakeDict()
    {
        Dictionary<int, robe> dict = new Dictionary<int, robe>();

        foreach (robe stat in robeData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class robe_randart : itemStat { }
[Serializable]
public class robe_randartStatData : ILoader<int, robe_randart>
{
    public List<robe_randart> robe_randartData = new List<robe_randart>();

    public Dictionary<int, robe_randart> MakeDict()
    {
        Dictionary<int, robe_randart> dict = new Dictionary<int, robe_randart>();

        foreach (robe_randart stat in robe_randartData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class shield : itemStat { }
[Serializable]
public class shieldStatData : ILoader<int, shield>
{
    public List<shield> shieldData = new List<shield>();

    public Dictionary<int, shield> MakeDict()
    {
        Dictionary<int, shield> dict = new Dictionary<int, shield>();

        foreach (shield stat in shieldData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class spear : itemStat { }
[Serializable]
public class spearStatData : ILoader<int, spear>
{
    public List<spear> spearData = new List<spear>();

    public Dictionary<int, spear> MakeDict()
    {
        Dictionary<int, spear> dict = new Dictionary<int, spear>();

        foreach (spear stat in spearData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class spear_randart : itemStat { }
[Serializable]
public class spear_randartStatData : ILoader<int, spear_randart>
{
    public List<spear_randart> spear_randartData = new List<spear_randart>();

    public Dictionary<int, spear_randart> MakeDict()
    {
        Dictionary<int, spear_randart> dict = new Dictionary<int, spear_randart>();

        foreach (spear_randart stat in spear_randartData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class staff : itemStat { }
[Serializable]
public class staffStatData : ILoader<int, staff>
{
    public List<staff> staffData = new List<staff>();

    public Dictionary<int, staff> MakeDict()
    {
        Dictionary<int, staff> dict = new Dictionary<int, staff>();

        foreach (staff stat in staffData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class sword : itemStat { }
[Serializable]
public class swordStatData : ILoader<int, sword>
{
    public List<sword> swordData = new List<sword>();

    public Dictionary<int, sword> MakeDict()
    {
        Dictionary<int, sword> dict = new Dictionary<int, sword>();

        foreach (sword stat in swordData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class sword_randart : itemStat { }
[Serializable]
public class sword_randartStatData : ILoader<int, sword_randart>
{
    public List<sword_randart> sword_randartData = new List<sword_randart>();

    public Dictionary<int, sword_randart> MakeDict()
    {
        Dictionary<int, sword_randart> dict = new Dictionary<int, sword_randart>();

        foreach (sword_randart stat in sword_randartData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class potion : itemStat
{
    public int _current_hp;
    public int _current_mp;
    public int _invisible;
    public int _gold;
    public int _Lv;
    public int _noMove;
    public int _turn;
}
[Serializable]
public class potionStatData : ILoader<int, potion>
{
    public List<potion> potionData = new List<potion>();

    public Dictionary<int, potion> MakeDict()
    {
        Dictionary<int, potion> dict = new Dictionary<int, potion>();

        foreach (potion stat in potionData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

[Serializable]
public class scroll : potion { }
[Serializable]
public class scrollStatData : ILoader<int, scroll>
{
    public List<scroll> scrollData = new List<scroll>();

    public Dictionary<int, scroll> MakeDict()
    {
        Dictionary<int, scroll> dict = new Dictionary<int, scroll>();

        foreach (scroll stat in scrollData)
            dict.Add(stat._No, stat);

        return dict;
    }
}

public class magic : itemStat
{
    public int _base_damage;
    public int _max_damage;
    public int _reach;
    public int _range;
    public int _type;
    public int _mp_consume;
    public int _property;
    public int _skill_level;
    public int _turn_duration;
    public int _effect;
}

[Serializable]
public class magicStatData : ILoader<int, magic>
{
    public List<magic> magicData = new List<magic>();

    public Dictionary<int, magic> MakeDict()
    {
        Dictionary<int, magic> dict = new Dictionary<int, magic>();

        foreach (magic stat in magicData)
            dict.Add(stat._No, stat);

        return dict;
    }
}
