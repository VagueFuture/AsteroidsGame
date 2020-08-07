using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LvlData", menuName = "Lvl Data", order = 51)]
public class Lvls_data : ScriptableObject
{
    public int numberLvl;
    public string lvlName;
    public string description;
    public string complexity;
    [Range(1,50)]
    public int doge_count_to_win;
    public int doge_count_lost_to_losing = -1;
    public float speedSpawn;
    [Range(10,50)]
    public int maxAsteroidSpeed = 10;
    public bool access;
    public bool complite;
}
