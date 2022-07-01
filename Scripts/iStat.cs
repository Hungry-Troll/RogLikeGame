using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iStat : MonoBehaviour
{
    [SerializeField]
    int _No;
    [SerializeField]
    string _Name;
    [SerializeField]
    int _max_hp;
    [SerializeField]
    int _max_mp;
    [SerializeField]
    int _min_attack;
    [SerializeField]
    int _max_attack;
    [SerializeField]
    int _defence;
    [SerializeField]
    int _min_magic_attack;
    [SerializeField]
    int _max_magic_attack;
    [SerializeField]
    int _fire_res;
    [SerializeField]
    int _cold_res;
    [SerializeField]
    int _earth_res;
    [SerializeField]
    int _dark_res;
    [SerializeField]
    int _poison_res;
    [SerializeField]
    int _accuracy;
    [SerializeField]
    int _avoid;
    [SerializeField]
    int _enhance;
    [SerializeField]
    int _str_limit;
    [SerializeField]
    int _dex_limit;
    [SerializeField]
    int _int_limit;
    [SerializeField]
    int _Hand;
    [SerializeField]
    int _enhance_limit;
    [SerializeField]
    string _NickName;


    public int No { get { return _No; } set { _No = value; } }
    public string Name { get { return _Name; } set { _Name = value; } }
    public int max_hp { get { return max_hp; } set { max_hp = value; } }
    public int max_mp { get { return max_mp; } set { max_mp = value; } }
    public int min_attack { get { return min_attack; } set { min_attack = value; } }
    public int max_attack { get { return max_attack; } set { max_attack = value; } }
    public int defence { get { return defence; } set { defence = value; } }
    public int min_magic_attack { get { return min_magic_attack; } set { min_magic_attack = value; } }
    public int max_magic_attack { get { return max_magic_attack; } set { max_magic_attack = value; } }
    public int fire_res { get { return fire_res; } set { fire_res = value; } }
    public int cold_res { get { return fire_res; } set { cold_res = value; } }
    public int earth_res;
    public int dark_res;
    public int poison_res;
    public int accuracy;
    public int avoid;
    public int enhance;
    public int str_limit;
    public int dex_limit;
    public int int_limit;
    public int Hand;
    public int enhance_limit;
    public string NickName;

}
