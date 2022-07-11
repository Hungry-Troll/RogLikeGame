using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{
    
    public int Max100 = 100;

    //아이템을 선택할 때 사용 예정
    public enum ItemList
    {
        Axe,
        Axe_randart,
        Boot,
        Bow,
        Bow_randart,
        Glove,
        Helmet,
        Helmet_randart,
        Mace,
        Mace_randart,
        Ring,
        Ring_randart,
        Robe,
        Robe_randart,
        Shield,
        Spear,
        Spear_randart,
        Staff,
        Sword,
        Sword_randart,
        Magic,
        Potion,
        Scroll,
        None,
    }

    public enum MapControll
    {
        SumMonster,
        SumPlayerStairUp,
        SumPlayerStairDown,
        SumItem,

    }

    public enum SkillList
    {
        Attack,
        Arrow,
        None,
    }

    public enum MonsterIdleState
    {
        Patrol,
        Follow,
        None,
    }

    public enum CreatureState
    {
        Idle,
        Moving,
        Skill,
        Dead,
        None,
    }

    public enum MoveDir
    {
        None,
        Up,
        Down,
        Left,
        Right,
    }

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }
    
    public enum UIEvent
    {
        Click,
        Drag,
    }
}
