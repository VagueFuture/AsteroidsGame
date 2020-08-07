using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_stats : MonoBehaviour
{
    public int live = 3;
    private int doge_count = 0;
    private Player_controller controller;
    void Start()
    {
        controller = GetComponentInChildren<Player_controller>();
    }

    public void Hit(){
        gameObject.GetComponent<AudioSource>().Play();
        if(!controller.dodge)
            live--;
        
        doge_count-=2;
        if(doge_count<0)
            doge_count = 0; 
        controller.GetDamage();
    }

    public int GetDogeCount(){
        return doge_count;
    }

    public void SetDogeCount(int count){
        doge_count+=count;
    }
}
