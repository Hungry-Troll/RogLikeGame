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
    //아이템 데이터
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

    public Dictionary<int, potion> potionStatDict { get; private set; } = new Dictionary<int, potion>();
    public Dictionary<int, scroll> scrollStatDict { get; private set; } = new Dictionary<int, scroll>();
    public Dictionary<int, magic> magicStatDict { get; private set; } = new Dictionary<int, magic>();

    //드랍 테이블
    public Dictionary<string, amulet_ItemTable> amulet_TableDict { get; private set; } = new Dictionary<string, amulet_ItemTable>();
    public Dictionary<string, armor_ItemTable> armor_TableDict { get; private set; } = new Dictionary<string, armor_ItemTable>();
    public Dictionary<string, axe_ItemTable> axe_TableDict { get; private set; } = new Dictionary<string, axe_ItemTable>();
    public Dictionary<string, boot_ItemTable> boot_TableDict { get; private set; } = new Dictionary<string, boot_ItemTable>();
    public Dictionary<string, bow_ItemTable> bow_TableDict { get; private set; } = new Dictionary<string, bow_ItemTable>();
    public Dictionary<string, glove_ItemTable> glove_TableDict { get; private set; } = new Dictionary<string, glove_ItemTable>();
    public Dictionary<string, helmet_ItemTable> helmet_TableDict { get; private set; } = new Dictionary<string, helmet_ItemTable>();
    public Dictionary<string, mace_ItemTable> mace_TableDict { get; private set; } = new Dictionary<string, mace_ItemTable>();
    public Dictionary<string, magic_ItemTable> magic_TableDict { get; private set; } = new Dictionary<string, magic_ItemTable>();
    public Dictionary<string, potion_ItemTable> potion_TableDict { get; private set; } = new Dictionary<string, potion_ItemTable>();
    public Dictionary<string, ring_ItemTable> ring_TableDict { get; private set; } = new Dictionary<string, ring_ItemTable>();
    public Dictionary<string, robe_ItemTable> robe_TableDict { get; private set; } = new Dictionary<string, robe_ItemTable>();
    public Dictionary<string, scroll_ItemTable> scroll_TableDict { get; private set; } = new Dictionary<string, scroll_ItemTable>();
    public Dictionary<string, shield_ItemTable> shield_TableDict { get; private set; } = new Dictionary<string, shield_ItemTable>();
    public Dictionary<string, spear_ItemTable> spear_TableDict { get; private set; } = new Dictionary<string, spear_ItemTable>();
    public Dictionary<string, staff_ItemTable> staff_TableDict { get; private set; } = new Dictionary<string, staff_ItemTable>();
    public Dictionary<string, sword_ItemTable> sword_TableDict { get; private set; } = new Dictionary<string, sword_ItemTable>();




    //public Dictionary<int, PlayerStat> TestDict = new Dictionary<int, PlayerStat>();
    


    public void Init()
    {
        //아이템
        PlayerStatDict = LoadJson<PlayerStatData, int, PlayerStat>("Player/PlayerStatData").MakeDict();
        MonsterStatDict = LoadJson<MonsterStatData, string, MonsterStat>("Monster/MonsterStatData").MakeDict();
        axeStatDict = LoadJson<axeStatData, int, axe>("Item/axe").MakeDict();
        axe_randartStatDict = LoadJson<axe_randartStatData, int, axe_randart>("Item/axe_randart").MakeDict();
        bootStatDict = LoadJson<bootStatData, int, boot>("Item/boot").MakeDict();
        bowStatDict = LoadJson<bowStatData, int, bow>("Item/bow").MakeDict();
        bow_randartStatDict = LoadJson<bow_randartStatData, int, bow_randart>("Item/bow_randart").MakeDict();
        gloveStatDict = LoadJson<gloveStatData, int, glove>("Item/glove").MakeDict();
        helmetStatDict = LoadJson<helmetStatData, int, helmet>("Item/helmet").MakeDict();
        helmet_randartStatDict = LoadJson<helmet_randartStatData, int, helmet_randart>("Item/helmet_randart").MakeDict();
        maceStatDict = LoadJson<maceStatData, int, mace>("Item/mace").MakeDict();
        ringStatDict = LoadJson<ringStatData, int, ring>("Item/ring").MakeDict();
        ring_randartStatDict = LoadJson<ring_randartStatData, int, ring_randart>("Item/ring_randart").MakeDict();
        robeStatDict = LoadJson<robeStatData, int, robe>("Item/robe").MakeDict();
        robe_randartStatDict = LoadJson<robe_randartStatData, int, robe_randart>("Item/robe_randart").MakeDict();
        shieldStatDict = LoadJson<shieldStatData, int, shield>("Item/shield").MakeDict();
        spearStatDict = LoadJson<spearStatData, int, spear>("Item/spear").MakeDict();
        spear_randartStatDict = LoadJson<spear_randartStatData, int, spear_randart>("Item/spear_randart").MakeDict();
        staffStatDict = LoadJson<staffStatData, int, staff>("Item/staff").MakeDict();
        swordStatDict = LoadJson<swordStatData, int, sword>("Item/sword").MakeDict();
        sword_randartStatDict = LoadJson<sword_randartStatData, int, sword_randart>("Item/sword_randart").MakeDict();
        potionStatDict = LoadJson<potionStatData, int, potion>("Item/potion").MakeDict();
        scrollStatDict = LoadJson<scrollStatData, int, scroll>("Item/scroll").MakeDict();
        magicStatDict = LoadJson<magicStatData, int, magic>("Item/magic").MakeDict();

        //드랍테이블
      

        //TestDict = LoadJson<PlayerStatData, int, PlayerStat>("Player/PlayerStatData").MakeDict();

    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = GameManager.Resouce.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }

}
