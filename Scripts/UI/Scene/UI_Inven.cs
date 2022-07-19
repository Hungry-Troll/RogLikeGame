using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inven : UI_Scene
{
    enum Buttons
    {
        State_Button,
        Bag_Button,
        Potion_Button,
        Book_Button,
        Skill_Button,
        Controller_Button,
    }

    enum GameObjects
    {
        GridPanel
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);

        //foreach (Transform child in gridPanel.transform)
            //GameManager.Resouce.Destroy(child.gameObject);


        //클릭시 사용 각각 함수를 만들어서 사용해야 됨
        GetButton((int)Buttons.State_Button).gameObject.BindEvent(StateButtonClicked);
        GetButton((int)Buttons.Bag_Button).gameObject.BindEvent(BagButtonClicked);
        GetButton((int)Buttons.Potion_Button).gameObject.BindEvent(PotionButtonClicked);
        GetButton((int)Buttons.Book_Button).gameObject.BindEvent(BookButtonClicked);
        GetButton((int)Buttons.Skill_Button).gameObject.BindEvent(SkillButtonClicked);
        GetButton((int)Buttons.Controller_Button).gameObject.BindEvent(ControllerButtonClicked);

        //추후 실제 인벤토리 정보를 참고해서 인벤토리를 만들어야 함
        for (int i = 0; i < 3; i++)
        {

            int random = Random.Range(0, 2);
            if (random == 1)
            {
                GameObject item = GameManager.Ui.MakeSubItme<UI_Inven_Item>(parent: gridPanel.transform).gameObject;
            }
            else
            {
                GameObject ring = GameManager.Ui.MakeSubItme<UI_Inven_Ring>(parent: gridPanel.transform).gameObject;
            }

            //GameObject item = GameManager.Ui.MakeSubItme<UI_Inven_Item>(parent : gridPanel.transform).gameObject;
            /*UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>();
            invenItem.SetInfo($"집행검{ i}번");*/
        }

        for (int i = 0; i < 18; i++)
        {
                GameObject item = GameManager.Ui.MakeSubItme<UI_Inven_Empty>(parent: gridPanel.transform).gameObject;
 
            //GameObject item = GameManager.Ui.MakeSubItme<UI_Inven_Item>(parent : gridPanel.transform).gameObject;
            /*UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>();
            invenItem.SetInfo($"집행검{ i}번");*/
        }
    }

    public void StateButtonClicked(PointerEventData data)
    {
       
    }

    public void BagButtonClicked(PointerEventData data)
    {

    }

    public void PotionButtonClicked(PointerEventData data)
    {

    }

    public void BookButtonClicked(PointerEventData data)
    {

    }

    public void SkillButtonClicked(PointerEventData data)
    {
        GameManager.Ui.CloseSceneUI();
    }

    public void ControllerButtonClicked(PointerEventData data)
    {

        GameManager.Ui.ShowSceneUI<UI_DirBase>();
    }
}
