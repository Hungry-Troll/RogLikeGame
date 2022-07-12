using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;


public class SummonManager
{
    public Define.ItemList _itemList = ItemList.None;

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

        string testWord = "axe";

        for (int i = 0; i < 23; i++)
        {
            //추후 제거할 코드

            axe _axe = itemSumTest();

            //랜다트 코드 임 테스트용
            //axe_randart _axeRan = itmeSumTestRandart();
            string _axeNickName = _axe._NickName;
            GameObject item = GameManager.Resouce.Instantiate($"Item/Equip/{testWord}/{_axeNickName}");

            //제거 해야 됨


            //위에 코드 제거 후 아래 주석 풀어야됨 일단 테스트 용도임
            //GameObject item = GameManager.Resouce.Instantiate($"Item/Equip/{testWord}/{testWord}{i + 1}");
            item.name = ($"{testWord}{i+1}");
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
    public axe itemSumTest()
    {
        //랜덤아티팩트는 딕셔너리가 다름
        //axe_ItemTable axeItemTable = GameManager.Data.axe_TableDict["RanArti"];



        axe_ItemTable axeItemTable= GameManager.Data.axe_TableDict["FirckArti"];
        //axe_ItemTable axeItemTable = GameManager.Data.axe_TableDict["NoArti"];
        int startNum = axeItemTable._startNum;
        int endNum = axeItemTable._endNum;

        int random = Random.Range(startNum, endNum + 1);

        //랜덤 아티팩트는 딕셔너리가 다름 리턴값도 변경해야됨, 일단 테스트니까 넘어감
        //axe_randart axeSumNum = GameManager.Data.axe_randartStatDict[random];

        axe axeSumNum = GameManager.Data.axeStatDict[random];

        return axeSumNum;
    }

    // 랜덤 아티팩트 함수 테스트용 추후 제거

    public axe_randart itmeSumTestRandart()
    {
        //랜덤아티팩트는 딕셔너리가 다름
        axe_ItemTable axeItemTable = GameManager.Data.axe_TableDict["RanArti"];



        //axe_ItemTable axeItemTable = GameManager.Data.axe_TableDict["FirckArti"];
        //axe_ItemTable axeItemTable = GameManager.Data.axe_TableDict["NoArti"];
        int startNum = axeItemTable._startNum;
        int endNum = axeItemTable._endNum;

        int random = Random.Range(startNum, endNum + 1);

        //랜덤 아티팩트는 딕셔너리가 다름 리턴값도 변경해야됨, 일단 테스트니까 넘어감
        axe_randart axeSumNum = GameManager.Data.axe_randartStatDict[random];

        //axe_randart axeSumNum = GameManager.Data.axeStatDict[random];

        return axeSumNum;
    }


    public void ItemPool()
    {
        //소모성 아이템 장착 아이템 계산 추후 확률을 바꿔야 될거 같음
        //아이템 셀렉에서 어떤 종류의 아이템 까지 결정됨
        itemSelect();
        //아이템 등급을 결정
        itemGradeCal();


        //아이템 소모품 확률을 어느정도로 할지 생각해야됨 지금은 대충 50%?? 정도 구상
        //플레이어 스킬레벨에 따른 아이템 드랍율도 생각해야됨

        //당장은 장비 구현만 우선 해보고 장비 능력치 잘 들어가는지 체크 해볼 것
        //구현만 하고 테스트는 모든 장비를 다 하나씩 불러와서 해야됨 그때는 아이템 풀로 하지말고 하드코딩
        //특히 랜다트 쪽은 버그가 날 수 있음 주의

        // 확률에 따라서 노멀 // 랜다트 // 픽다트 나옴


    }

    public void itemSelect()
    {
        int itemCheck = Random.Range(0, 10);
        if (itemCheck <= 5)
            itemComsum();
        else
            itemEquip();
    }

    public void itemComsum()
    {
        int itemRan = Random.Range(0, 100);
        if (itemRan <= 39)
            _itemList = ItemList.Potion;
        if (itemRan > 40 && itemRan <= 69)
            _itemList = ItemList.Scroll;
        else
            _itemList = ItemList.Magic;

    }

    public void itemEquip()
    {
        int itemRan = Random.Range(0, 20);
        switch (itemRan)
        {
            case 0: _itemList = ItemList.Axe; break;
            case 1: _itemList = ItemList.Axe_randart; break;
            case 2: _itemList = ItemList.Boot; break;
            case 3: _itemList = ItemList.Bow; break;
            case 4: _itemList = ItemList.Bow_randart; break;
            case 5: _itemList = ItemList.Glove; break;
            case 6: _itemList = ItemList.Helmet; break;
            case 7: _itemList = ItemList.Helmet_randart; break;
            case 8: _itemList = ItemList.Mace; break;
            case 9: _itemList = ItemList.Mace_randart; break;
            case 10: _itemList = ItemList.Ring; break;
            case 11: _itemList = ItemList.Ring_randart; break;
            case 12: _itemList = ItemList.Robe; break;
            case 13: _itemList = ItemList.Robe_randart; break;
            case 14: _itemList = ItemList.Shield; break;
            case 15: _itemList = ItemList.Spear; break;
            case 16: _itemList = ItemList.Spear_randart; break;
            case 17: _itemList = ItemList.Staff; break;
            case 18: _itemList = ItemList.Sword; break;
            case 19: _itemList = ItemList.Sword_randart; break;

                //case 20: _itemList = Define.ItemList.None; break;
        }
    }

    public void itemGradeCal()
    {
        int ran = Random.Range(1, 101);
        if (ran <= 5)
            FickArti();
        else if (ran <= 15)
            RanArti();
        else
            NoArti();
    }

    public void NoArti()
    {
        

        switch (_itemList)
        {
            case ItemList.Axe: axe_ItemTable axeItemTable = GameManager.Data.axe_TableDict["NoArti"]; break;
            case ItemList.Axe_randart: _itemList = ItemList.Axe_randart; break;
            case ItemList.Boot: _itemList = ItemList.Boot; break;
            case ItemList.Bow: _itemList = ItemList.Bow; break;
            case ItemList.Bow_randart: _itemList = ItemList.Bow_randart; break;
            case ItemList.Glove: _itemList = ItemList.Glove; break;
            case ItemList.Helmet: _itemList = ItemList.Helmet; break;
            case ItemList.Helmet_randart: _itemList = ItemList.Helmet_randart; break;
            case ItemList.Mace: _itemList = ItemList.Mace; break;
            case ItemList.Mace_randart: _itemList = ItemList.Mace_randart; break;
            case ItemList.Ring: _itemList = ItemList.Ring; break;
            case ItemList.Ring_randart: _itemList = ItemList.Ring_randart; break;
            case ItemList.Robe: _itemList = ItemList.Robe; break;
            case ItemList.Robe_randart: _itemList = ItemList.Robe_randart; break;
            case ItemList.Shield: _itemList = ItemList.Shield; break;
            case ItemList.Spear: _itemList = ItemList.Spear; break;
            case ItemList.Spear_randart: _itemList = ItemList.Spear_randart; break;
            case ItemList.Staff: _itemList = ItemList.Staff; break;
            case ItemList.Sword: _itemList = ItemList.Sword; break;
            case ItemList.Sword_randart: _itemList = ItemList.Sword_randart; break;
            case ItemList.Potion: _itemList = ItemList.Potion; break;
            case ItemList.Scroll: _itemList = ItemList.None; break;
            case ItemList.Magic: _itemList = ItemList.None; break;
        }
    }

    public void RanArti()
    {
        
    }

    public void FickArti()
    {


    }

}
