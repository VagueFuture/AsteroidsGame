using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doge : MonoBehaviour
{
    public AudioSource picUp;
    public GameObject doge;
    public GameObject particleBoom,particleLove;
    private bool dead;
    private float _timer = 0; 
    private AudioSource audit;
    private bool player;
    private Game_controller controller;

    private void Start() {
        audit = gameObject.GetComponent<AudioSource>();
        GameObject contr = GameObject.Find("Game_logick");
        if(contr != null){
            controller = contr.GetComponent<Game_controller>();
        }
    }
    void FixedUpdate()
    {
        if(!dead)
            doge.transform.Rotate(0,0,5);
        else{
            if(_timer>0.36f){
                particleBoom.SetActive(false);
                particleLove.SetActive(false);
                doge.SetActive(true);
                gameObject.SetActive(false);
                _timer = 0;
                dead = false;
                player = false;
            }
            _timer+=Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(!dead){
            if(other.tag == "Player"){
                player = true;
                picUp.Play();
                other.GetComponent<Player_stats>().SetDogeCount(1);
                Dead();
            }
            if(other.tag == "Bullet"){
                Debug.Log("Bullet kill doge (");
                other.gameObject.SetActive(false);
                Dead();
            }
        }
    }

    public void Dead(){
        dead = true;
        if(!player){
            audit.Play();
            gameObject.GetComponent<AudioSource>().Play();
            if(controller!= null)
                controller.lostDoge++;
            particleBoom.SetActive(true);
            }
        else
            particleLove.SetActive(true);

        doge.SetActive(false);
    }
}
