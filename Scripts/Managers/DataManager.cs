using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class Test
{

}

public class DataManager 
{
    public Dictionary<int, PlayerStat> PlayerStatDict { get; private set; } = new Dictionary<int, PlayerStat>();
    public Dictionary<string, MonsterStat> MonsterStatDict { get; private set; } = new Dictionary<string, MonsterStat>();
    public Dictionary<int, axe> axeStatDict { get; private set; } = new Dictionary<int, axe>();
    public Dictionary<int, axe_randart> axe_randartStatDict { get; private set; } = new Dictionary<int, axe_randart>();
    public Dictionary<int, boot> bootStatDict { get; private set; } = new Dictionary<int, boot>();
    public Dictionary<int, bow> bowStatDict { get; private set; } = new Dictionary<int, bow>();
    public Dictionary<int, bow_randart> bow_randartStatDict { get; private set; } = new Dictionary<int, bow_randart>();
    public Dictionary<int, glove> gloveStatDict { get; private set; } = new Dictionary<int, glove>();
    public Dictionary<int, helmet> helmetStatDict { get; private set; } = new Dictionary<int, helmet>();
    public Dictionary<int, helmet_randart> helmet_randartStatDict { get; private set; } = new Dictionary<int, helmet_randart>();
    public Dictionary<int, mace> maceStatDict { get; private set; } = new Dictionary<int, mace>();
    public Dictionary<int, mace_randart> mace_randartStatDict { get; private set; } = new Dictionary<int, mace_randart>();
    public Dictionary<int, ring> ringStatDict { get; private set; } = new Dictionary<int, ring>();
    public Dictionary<int, ring_randart> ring_randartStatDict { get; private set; } = new Dictionary<int, ring_randart>();
    public Dictionary<int, robe> robeStatDict { get; private set; } = new Dictionary<int, robe>();
    public Dictionary<int, robe_randart> robe_randartStatDict { get; private set; } = new Dictionary<int, robe_randart>();
    public Dictionary<int, shield> shieldStatDict { get; private set; } = new Dictionary<int, shield>();
    public Dictionary<int, spear> spearStatDict { get; private set; } = new Dictionary<int, spear>();
    public Dictionary<int, spear_randart> spear_randartStatDict { get; private set; } = new Dictionary<int, spear_randart>();
    public Dictionary<int, staff> staffStatDict { get; private set; } = new Dictionary<int, staff>();
    public Dictionary<int, sword> swordStatDict { get; private set; } = new Dictionary<int, sword>();
    public Dictionary<int, sword_randart> sword_randartStatDict { get; private set; } = new Dictionary<int, sword_randart>();
    public Dictionary<int, potionStatData> potionStatDict { get; private set; } = new Dictionary<int, potionStatData>();



    public Dictionary<string, Test> TestDict = new Dictionary<string, Test>();
    


    public void Init()
    {
        PlayerStatDict = LoadJson<PlayerStatData, int, PlayerStat>("PlayerStatData").MakeDict();
        MonsterStatDict = LoadJson<MonsterStatData, string, MonsterStat>("MonsterStatData").MakeDict();
        axeStatDict = LoadJson<axeStatData, int, axe>("axe").MakeDict();
        axe_randartStatDict = LoadJson<axe_randartStatData, int, axe_randart>("axe_randart").MakeDict();
        bootStatDict = LoadJson<bootStatData, int, boot>("boot").MakeDict();
        bowStatDict = LoadJson<bowStatData, int, bow>("bow").MakeDict();
        bow_randartStatDict = LoadJson<bow_randartStatData, int, bow_randart>("bow_randart").MakeDict();
        gloveStatDict = LoadJson<gloveStatData, int, glove>("glove").MakeDict();
        helmetStatDict = LoadJson<helmetStatData, int, helmet>("helmet").MakeDict();
        helmet_randartStatDict = LoadJson<helmet_randartStatData, int, helmet_randart>("helmet_randart").MakeDict();
        maceStatDict = LoadJson<maceStatData, int, mace>("mace").MakeDict();
        ringStatDict = LoadJson<ringStatData, int, ring>("ring").MakeDict();
        ring_randartStatDict = LoadJson<ring_randartStatData, int, ring_randart>("ring_randart").MakeDict();
        robeStatDict = LoadJson<robeStatData, int, robe>("robe").MakeDict();
        robe_randartStatDict = LoadJson<robe_randartStatData, int, robe_randart>("robe_randart").MakeDict();
        shieldStatDict = LoadJson<shieldStatData, int, shield>("shield").MakeDict();
        spearStatDict = LoadJson<spearStatData, int, spear>("spear").MakeDict();
        spear_randartStatDict = LoadJson<spear_randartStatData, int, spear_randart>("spear_randart").MakeDict();
        staffStatDict = LoadJson<staffStatData, int, staff>("staff").MakeDict();
        swordStatDict = LoadJson<swordStatData, int, sword>("sword").MakeDict();
        sword_randartStatDict = LoadJson<sword_randartStatData, int, sword_randart>("sword_randart").MakeDict();
        potionStatDict = LoadJson<potionStatData, int, potion>("potion").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = GameManager.Resouce.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }

}
