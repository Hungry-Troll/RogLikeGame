using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{
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
