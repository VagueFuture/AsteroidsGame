using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dog_reaction : MonoBehaviour
{
   // public GameObject Dog_image;
    public List<Sprite> image = new List<Sprite>();
    private Player_stats stats;
    private int hp;
    private int dCount;
    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_stats>();
        hp = stats.live;
        dCount = stats.GetDogeCount();
    }

    private void FixedUpdate() {
        if(_timer<2)
            _timer+= Time.deltaTime;
        int nowHp;
        int nowDCount;

        nowHp = stats.live;
        nowDCount = stats.GetDogeCount();

        if(hp!= nowHp){
            changeimage(1);
            hp = nowHp;
        }
        if(dCount != nowDCount){
            changeimage(2);
            dCount = nowDCount;
        }

        if(_timer>0.5f){
            gameObject.GetComponent<Image>().sprite= image[0];
        }
    }

    private void changeimage(int num){
        gameObject.GetComponent<Image>().sprite= image[num];
        _timer = 0;
    }
}
