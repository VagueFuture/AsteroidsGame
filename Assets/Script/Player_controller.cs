using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public AudioSource barellAudio;
    public DynamicJoystick dynamicJoystick;
    private Pool_objects pool;
    private Animator mayAnim;
    public float horizontal;
    public float jump;
    public bool dodge;
    private float _timerShoot = 0.5f;
    void Start()
    {
        mayAnim = GetComponentInChildren<Animator>();
        pool = GetComponentInChildren<Pool_objects>();
    }

    public void Update()
    {
        MoveUpdate();
        ActionUpdate();
    }

    public void MoveUpdate()
    {
        horizontal = Input.GetAxis("Horizontal")+dynamicJoystick.Horizontal;
        mayAnim.SetFloat("blend", horizontal, 0.15f, Time.deltaTime);
    }

    public void ActionUpdate()
    {
        if((Input.GetButtonDown("Jump")) && !dodge)
        {
            dodge = true;
            mayAnim.SetBool("dodge",true);
        }

        if(Input.GetButtonDown("Fire1")){
            pool.Shoot(2000);
            barellAudio.Play();
        }
        
        //Shooting while moving on the stick
        if(Input.touchCount == 2){
            _timerShoot+=Time.deltaTime;
            if(_timerShoot>0.5f){
                pool.Shoot(2000);
                barellAudio.Play();
                _timerShoot = 0;
            }
        }else{
            _timerShoot = 0.5f;
        }
    }

    public void endAnims(){
        dodge = false;
        mayAnim.SetBool("dodge",false);
        mayAnim.SetBool("damage",false);
    }

    public void GetDamage(){
        mayAnim.SetBool("damage",true);
    }

}
