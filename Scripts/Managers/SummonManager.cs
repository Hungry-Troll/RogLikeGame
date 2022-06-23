using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;


public class SummonManager
{
    public Define.ItemList _itemList = ItemList.None;

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

        for (int i = 0; i < 5; i++)
        {
            GameObject item = GameManager.Resouce.Instantiate("Item/Equip/sword1");
            item.name = "sword1";
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

    public void ItemPool()
    {
        //아이템 소모품 확률을 어느정도로 할지 생각해야됨 지금은 대충 50%?? 정도 구상
        //플레이어 스킬레벨에 따른 아이템 드랍율도 생각해야됨

        //당장은 장비 구현만 우선 해보고 장비 능력치 잘 들어가는지 체크 해볼 것
        //구현만 하고 테스트는 모든 장비를 다 하나씩 불러와서 해야됨 그때는 아이템 풀로 하지말고 하드코딩
        //특히 랜다트 쪽은 버그가 날 수 있음 주의


        // 아이템 종류 선정
        int itemRan = UnityEngine.Random.Range(0, 20);
        switch (itemRan)
        {
            case 0: _itemList = ItemList.Axe; break;
            case 1: _itemList = ItemList.Axe_randart; break;
            case 2: _itemList = ItemList.Boot; break;
            case 3: _itemList = ItemList.Bow; break;
            case 4: _itemList = ItemList.Bow_randart; break;
            case 5: _itemList = ItemList.Glove; break;
            case 6: _itemList = ItemList.Helmet;break;
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

        // 확률에 따라서 노멀 // 랜다트 // 픽다트 나옴
        int ran = UnityEngine.Random.Range(1, 101);
        if (ran >= 5)
            FickArti();
        else if (ran > 15)
            RanArti();
        else
            NoArti();

    }

    public void NoArti()
    {
        switch (_itemList)
        {
            case ItemList.Axe: break;
            case ItemList.Axe_randart: break;
            case ItemList.Boot: break;
            case ItemList.Bow: break;
            case ItemList.Bow_randart: break;
            case ItemList.Glove: break;
            case ItemList.Helmet: break;
            case ItemList.Helmet_randart: break;
            case ItemList.Mace: break;
            case ItemList.Mace_randart: break;
            case ItemList.Ring: break;
            case ItemList.Ring_randart: break;
            case ItemList.Robe: break;
            case ItemList.Robe_randart: break;
            case ItemList.Shield: break;
            case ItemList.Spear: break;
            case ItemList.Spear_randart: break;
            case ItemList.Staff: break;
            case ItemList.Sword: break;
            case ItemList.Sword_randart: break;
                //case 20: _itemList = Define.ItemList.None; break;
        }
    }

    public void RanArti()
    {

    }

    public void FickArti()
    {


    }

}
