using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;


public class SummonManager
{
    //아이템 등급 구분용
    public ItemGrade _itemGrade = ItemGrade.NoArti;

    //아이템 리스트
    public ItemList _itemList = ItemList.None;

    public void Init()
    {
        //플레이어 스텟처럼 지금의 데이터를 가지고 와서 저장할
        //스텟 스크립트를 만들어야 함
        //그다음에 게임매니저에 연결을 해야 되는대
        //데이터 다음으로 연결을 해 놔야 에러가 안생김

        //= GameManager.Data.axeStatDict;
    }

    public void MonsterCreat()
    {
        MapManager.SumPos sumPos = new MapManager.SumPos();

        for (int i = 0; i < 5; i++)
        {
            GameObject Slim = GameManager.Resouce.Instantiate("Creature/Ork");
            Slim.name = $"Ork_{i}";

            GameManager.Map._mapControll = MapControll.SumMonster;
            sumPos = GameManager.Map.CanSum();
            //int X = arr[0];
            //int Y = arr[1];

            Vector3Int pos = new Vector3Int()
            {
                x = sumPos.x,
                y = sumPos.y
            };

            MonsterController mc = Slim.GetComponent<MonsterController>();
            mc.CellPos = pos;

            GameManager.Obj.Add(Slim);
        }
    }

    public void PlayerCreat()
    {
        MapManager.SumPos sumPos = new MapManager.SumPos();

        GameObject player = GameManager.Resouce.Instantiate("Creature/Player");
        player.name = "Player";
        GameManager.Obj.Add(player);

        GameManager.Map._mapControll = MapControll.SumPlayerStairUp;
        sumPos = GameManager.Map.CanSum();
        //int X = arr[0];
        //int Y = arr[1];
        Vector3Int playerPos = new Vector3Int()
        {
            x = sumPos.x,
            y = sumPos.y
        };

        PlayerController pc = player.GetComponent<PlayerController>();
        pc.CellPos = playerPos;

    }


    public void ItemCreate()
    {
        MapManager.SumPos sumPos = new MapManager.SumPos();
        int item_No;
        #region
        /*        #region NextCoding
                switch (_itemList)
                {
                    case ItemList.Axe: 
                        break;
                    case ItemList.Boot:
                        break;
                    case ItemList.Bow:
                        break;
                    case ItemList.Glove:
                        break;
                    case ItemList.Helmet:
                        break;
                    case ItemList.Mace:
                        break;
                    case ItemList.Ring:
                        break;
                    case ItemList.Robe:
                        break;
                    case ItemList.Shield:
                        break;
                    case ItemList.Spear:
                        break;
                    case ItemList.Staff:
                        break;
                    case ItemList.Sword:
                        break;

                        //case 20: _itemList = Define.ItemList.None; break;
                }
        */

        #endregion

        if (_itemGrade == ItemGrade.RanArti)



        //string testWord = "axe";

        //int num = AxeCreate();
        for (int i = 0; i < 23; i++)
        {
            //추후 제거할 코드

            
            axe _axe = GameManager.Data.axeStatDict[1];
            string NickName =_axe._NickName;
            GameObject item = GameManager.Resouce.Instantiate($"item/Equip/axe/{NickName}");




            //위에 코드 제거 후 아래 주석 풀어야됨 일단 테스트 용도임
            //GameObject item = GameManager.Resouce.Instantiate($"Item/Equip/{testWord}/{testWord}{i + 1}");
            item.name = ($"test");
            GameManager.Obj.ItemAdd(item);
            GameManager.Map._mapControll = MapControll.SumItem;
            sumPos = GameManager.Map.CanSum();
            
            Vector3Int itemPos = new Vector3Int()
            {
                x = sumPos.x,
                y = sumPos.y
            };

            ItemController ic = item.GetOrAddComponent<ItemController>();
            ic.CellPos = itemPos;

        }

    }


    // 아이템 테스트용 함수 추후 제거 
    public glove itemSumTest()
    {
        //랜덤아티팩트는 딕셔너리가 다름
        glove_ItemTable gloveItemTable = GameManager.Data.glove_TableDict["RanArti"];


        //glove_ItemTable gloveItemTable= GameManager.Data.glove_TableDict["FirckArti"];
        //bow_ItemTable bowItemTable = GameManager.Data.bow_TableDict["NoArti"];
        int startNum = gloveItemTable._startNum;
        int endNum = gloveItemTable._endNum;

        int random = Random.Range(startNum, endNum + 1);

        //랜덤 아티팩트는 딕셔너리가 다름 리턴값도 변경해야됨, 일단 테스트니까 넘어감
        //axe_randart axeSumNum = GameManager.Data.axe_randartStatDict[random];

        glove axeSumNum = GameManager.Data.gloveStatDict[random];

        return axeSumNum;
    }

    // 랜덤 아티팩트 함수 테스트용 추후 제거

    public bow_randart itmeSumTestRandart()
    {
        //랜덤아티팩트는 딕셔너리가 다름
        bow_ItemTable axeItemTable = GameManager.Data.bow_TableDict["RanArti"];



        //axe_ItemTable axeItemTable = GameManager.Data.axe_TableDict["FirckArti"];
        //axe_ItemTable axeItemTable = GameManager.Data.axe_TableDict["NoArti"];
        int startNum = axeItemTable._startNum;
        int endNum = axeItemTable._endNum;

        int random = Random.Range(startNum, endNum + 1);

        //랜덤 아티팩트는 딕셔너리가 다름 리턴값도 변경해야됨, 일단 테스트니까 넘어감
        bow_randart axeSumNum = GameManager.Data.bow_randartStatDict[random];

        //axe_randart axeSumNum = GameManager.Data.axeStatDict[random];

        return axeSumNum;
    }


    public void ItemPool()
    {
        //소모성 아이템 장착 아이템 계산 추후 확률을 바꿔야 될거 같음
        //아이템 셀렉에서 어떤 종류의 아이템 까지 결정됨
        ItemSelect();
        //아이템 등급을 결정
        ItemGradeCal();


        //아이템 소모품 확률을 어느정도로 할지 생각해야됨 지금은 대충 50%?? 정도 구상
        //플레이어 스킬레벨에 따른 아이템 드랍율도 생각해야됨

        //당장은 장비 구현만 우선 해보고 장비 능력치 잘 들어가는지 체크 해볼 것
        //구현만 하고 테스트는 모든 장비를 다 하나씩 불러와서 해야됨 그때는 아이템 풀로 하지말고 하드코딩
        //특히 랜다트 쪽은 버그가 날 수 있음 주의

        // 확률에 따라서 노멀 // 랜다트 // 픽다트 나옴


    }

    public void ItemSelect()
    {
        int itemCheck = Random.Range(0, 10);
        if (itemCheck <= 5)
            ItemComsum();
        else
            ItemEquip();
    }

    public void ItemComsum()
    {
        int itemRan = Random.Range(0, 100);
        if (itemRan <= 39)
            _itemList = ItemList.Potion;
        if (itemRan > 40 && itemRan <= 69)
            _itemList = ItemList.Scroll;
        else
            _itemList = ItemList.Magic;

    }

    public void ItemEquip()
    {
        int itemRan = Random.Range(0, 12);
        switch (itemRan)
        {
            case 0: _itemList = ItemList.Axe; break;
            case 1: _itemList = ItemList.Boot; break;
            case 2: _itemList = ItemList.Bow; break;
            case 3: _itemList = ItemList.Glove; break;
            case 4: _itemList = ItemList.Helmet; break;
            case 5: _itemList = ItemList.Mace; break;
            case 6: _itemList = ItemList.Ring; break;
            case 7: _itemList = ItemList.Robe; break;
            case 8: _itemList = ItemList.Shield; break;
            case 9: _itemList = ItemList.Spear; break;
            case 10: _itemList = ItemList.Staff; break;
            case 11: _itemList = ItemList.Sword; break;
                //case 20: _itemList = Define.ItemList.None; break;
        }
    }

    public void ItemGradeCal()
    {
        int ran = Random.Range(1, 101);
        if (ran <= 5)
            _itemGrade = ItemGrade.FickArti;
        else if (ran <= 15)
            _itemGrade = ItemGrade.RanArti;
        else
            _itemGrade = ItemGrade.NoArti;
    }


    #region itemCreate


    public void ItemCraateEx()
    {

    }


    public void AxeCreate()
    {
        axe_ItemTable axeItemTable = null;

        switch(_itemGrade)
        {
            case ItemGrade.NoArti:
                axeItemTable = GameManager.Data.axe_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                axeItemTable = GameManager.Data.axe_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                axeItemTable = GameManager.Data.axe_TableDict["FirckArti"];
                break;
        }

        int startNum = axeItemTable._startNum; //딕 시작값
        int endNum = axeItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        string item_name; //리턴용
        if (_itemGrade == ItemGrade.RanArti)
        {
            axe_randart itemNum = GameManager.Data.axe_randartStatDict[random];
            item_name = itemNum._NickName;
        }
        else
        {
            axe itemNum = GameManager.Data.axeStatDict[random];
            item_name = itemNum._NickName;
        }
        GameObject item = GameManager.Resouce.Instantiate($"item/Equip/axe/{item_name}");
    }

    public int BootCreate()
    {
        boot_ItemTable bootItemTable = null;

        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                bootItemTable = GameManager.Data.boot_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                bootItemTable = GameManager.Data.boot_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                bootItemTable = GameManager.Data.boot_TableDict["FirckArti"];
                break;
        }

        int startNum = bootItemTable._startNum; //딕 시작값
        int endNum = bootItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int item_No; //리턴용

        //부츠는 랜다트 딕이 없음
        boot itemNum = GameManager.Data.bootStatDict[random];
        item_No = itemNum._No;

        return item_No;
    }

    public int BowCreate()
    {
        bow_ItemTable bowItemTable = null;

        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                bowItemTable = GameManager.Data.bow_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                bowItemTable = GameManager.Data.bow_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                bowItemTable = GameManager.Data.bow_TableDict["FirckArti"];
                break;
        }

        int startNum = bowItemTable._startNum; //딕 시작값
        int endNum = bowItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int item_No; //리턴용
        if (_itemGrade == ItemGrade.RanArti)
        {
            bow_randart itemNum = GameManager.Data.bow_randartStatDict[random];
            item_No = itemNum._No;
        }
        else
        {
            bow itemNum = GameManager.Data.bowStatDict[random];
            item_No = itemNum._No;
        }
        return item_No;
    }

    public int GloveCreate()
    {
        glove_ItemTable gloveItemTable = null;

        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                gloveItemTable = GameManager.Data.glove_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                gloveItemTable = GameManager.Data.glove_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                gloveItemTable = GameManager.Data.glove_TableDict["FirckArti"];
                break;
        }

        int startNum = gloveItemTable._startNum; //딕 시작값
        int endNum = gloveItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int item_No; //리턴용

        //글러브는 랜다트가 없음

        glove itemNum = GameManager.Data.gloveStatDict[random];
        item_No = itemNum._No;
        
        return item_No;

    }

    public int HelmetCreate()
    {
        helmet_ItemTable helmetItemTable = null;

        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                helmetItemTable = GameManager.Data.helmet_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                helmetItemTable = GameManager.Data.helmet_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                helmetItemTable = GameManager.Data.helmet_TableDict["FirckArti"];
                break;
        }

        int startNum = helmetItemTable._startNum; //딕 시작값
        int endNum = helmetItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int item_No; //리턴용
        if (_itemGrade == ItemGrade.RanArti)
        {
            helmet_randart itemNum = GameManager.Data.helmet_randartStatDict[random];
            item_No = itemNum._No;
        }
        else
        {
            helmet itemNum = GameManager.Data.helmetStatDict[random];
            item_No = itemNum._No;
        }
        return item_No;
    }

    public int MaceCreate()
    {
        mace_ItemTable maceItemTable = null;

        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                maceItemTable = GameManager.Data.mace_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                maceItemTable = GameManager.Data.mace_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                maceItemTable = GameManager.Data.mace_TableDict["FirckArti"];
                break;
        }

        int startNum = maceItemTable._startNum; //딕 시작값
        int endNum = maceItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int item_No; //리턴용
        if (_itemGrade == ItemGrade.RanArti)
        {
            mace_randart itemNum = GameManager.Data.mace_randartStatDict[random];
            item_No = itemNum._No;
        }
        else
        {
            mace itemNum = GameManager.Data.maceStatDict[random];
            item_No = itemNum._No;
        }
        return item_No;
    }

    public int RingCreate()
    {
        ring_ItemTable ringItemTable = null;

        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                ringItemTable = GameManager.Data.ring_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                ringItemTable = GameManager.Data.ring_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                ringItemTable = GameManager.Data.ring_TableDict["FirckArti"];
                break;
        }

        int startNum = ringItemTable._startNum; //딕 시작값
        int endNum = ringItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int item_No; //리턴용
        if (_itemGrade == ItemGrade.RanArti)
        {
            ring_randart itemNum = GameManager.Data.ring_randartStatDict[random];
            item_No = itemNum._No;
        }
        else
        {
            ring itemNum = GameManager.Data.ringStatDict[random];
            item_No = itemNum._No;
        }
        return item_No;
    }

    public int RobeCreate()
    {
        robe_ItemTable robeItemTable = null;

        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                robeItemTable = GameManager.Data.robe_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                robeItemTable = GameManager.Data.robe_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                robeItemTable = GameManager.Data.robe_TableDict["FirckArti"];
                break;
        }

        int startNum = robeItemTable._startNum; //딕 시작값
        int endNum = robeItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int item_No; //리턴용
        if (_itemGrade == ItemGrade.RanArti)
        {
            robe_randart itemNum = GameManager.Data.robe_randartStatDict[random];
            item_No = itemNum._No;
        }
        else
        {
            robe itemNum = GameManager.Data.robeStatDict[random];
            item_No = itemNum._No;
        }
        return item_No;
    }

    public int ShieldCreate()
    {
        shield_ItemTable shieldItemTable = null;

        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                shieldItemTable = GameManager.Data.shield_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                shieldItemTable = GameManager.Data.shield_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                shieldItemTable = GameManager.Data.shield_TableDict["FirckArti"];
                break;
        }

        int startNum = shieldItemTable._startNum; //딕 시작값
        int endNum = shieldItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int item_No; //리턴용

        shield itemNum = GameManager.Data.shieldStatDict[random];
        item_No = itemNum._No;
        
        return item_No;
    }


    public int SpearCreate()
    {
        spear_ItemTable spearItemTable = null;

        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                spearItemTable = GameManager.Data.spear_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                spearItemTable = GameManager.Data.spear_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                spearItemTable = GameManager.Data.spear_TableDict["FirckArti"];
                break;
        }

        int startNum = spearItemTable._startNum; //딕 시작값
        int endNum = spearItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int item_No; //리턴용
        if (_itemGrade == ItemGrade.RanArti)
        {
            spear_randart itemNum = GameManager.Data.spear_randartStatDict[random];
            item_No = itemNum._No;
        }
        else
        {
            spear itemNum = GameManager.Data.spearStatDict[random];
            item_No = itemNum._No;
        }
        return item_No;
    }


    public int StaffCreate()
    {
        staff_ItemTable staffItemTable = null;

        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                staffItemTable = GameManager.Data.staff_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                staffItemTable = GameManager.Data.staff_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                staffItemTable = GameManager.Data.staff_TableDict["FirckArti"];
                break;
        }

        int startNum = staffItemTable._startNum; //딕 시작값
        int endNum = staffItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int item_No; //리턴용

        staff itemNum = GameManager.Data.staffStatDict[random];
        item_No = itemNum._No;
        
        return item_No;
    }

    public int SwordCreate()
    {
        sword_ItemTable swordItemTable = null;

        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                swordItemTable = GameManager.Data.sword_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                swordItemTable = GameManager.Data.sword_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                swordItemTable = GameManager.Data.sword_TableDict["FirckArti"];
                break;
        }

        int startNum = swordItemTable._startNum; //딕 시작값
        int endNum = swordItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int item_No; //리턴용
        if (_itemGrade == ItemGrade.RanArti)
        {
            sword_randart itemNum = GameManager.Data.sword_randartStatDict[random];
            item_No = itemNum._No;
        }
        else
        {
            sword itemNum = GameManager.Data.swordStatDict[random];
            item_No = itemNum._No;
        }
        return item_No;
    }

    public int PotionCreate()
    {
        potion_ItemTable potionItemTable = null;

        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                potionItemTable = GameManager.Data.potion_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                potionItemTable = GameManager.Data.potion_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                potionItemTable = GameManager.Data.potion_TableDict["FirckArti"];
                break;
        }

        int startNum = potionItemTable._startNum; //딕 시작값
        int endNum = potionItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int item_No; //리턴용

        potion itemNum = GameManager.Data.potionStatDict[random];
        item_No = itemNum._No;

        return item_No;
    }


    public int ScrollCreate()
    {
        scroll_ItemTable scrollItemTable = null;

        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                scrollItemTable = GameManager.Data.scroll_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                scrollItemTable = GameManager.Data.scroll_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                scrollItemTable = GameManager.Data.scroll_TableDict["FirckArti"];
                break;
        }

        int startNum = scrollItemTable._startNum; //딕 시작값
        int endNum = scrollItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int item_No; //리턴용

        scroll itemNum = GameManager.Data.scrollStatDict[random];
        item_No = itemNum._No;

        return item_No;
    }

    public int MagicCreate()
    {
        magic_ItemTable magicItemTable = null;

        switch (_itemGrade)
        {
            case ItemGrade.NoArti:
                magicItemTable = GameManager.Data.magic_TableDict["NoArti"];
                break;
            case ItemGrade.RanArti:
                magicItemTable = GameManager.Data.magic_TableDict["RanArti"];
                break;
            case ItemGrade.FickArti:
                magicItemTable = GameManager.Data.magic_TableDict["FirckArti"];
                break;
        }

        int startNum = magicItemTable._startNum; //딕 시작값
        int endNum = magicItemTable._endNum; //딕 끝값
        int random = Random.Range(startNum, endNum + 1); //랜덤 _No 추출용

        int item_No; //리턴용

        magic itemNum = GameManager.Data.magicStatDict[random];
        item_No = itemNum._No;

        return item_No;
    }


    #endregion
}
