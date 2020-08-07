using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject rock;
    public GameObject particle;
    public float speed = 10;
    private Pool_objects poolDoge;
    private Vector3 wayPoint;
    private float _timer = 0;
    private bool dead,player;
    private int size;
    void Start()
    {
        poolDoge = GameObject.Find("PoolDoge").GetComponent<Pool_objects>();
        size=Random.Range(0,3);
        transform.localScale = new Vector3(1+size,1+size,1+size);
    }
    void FixedUpdate()
    {
        rock.transform.Rotate(0,0,2);
        if(!dead){
            wayPoint = new Vector3(transform.position.x,transform.position.y,transform.position.z-10);
            transform.position = Vector3.MoveTowards(transform.position,wayPoint,Time.deltaTime*speed);
        }else{
            if(_timer>0.36f){
                particle.SetActive(false);
                rock.SetActive(true);
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
                other.GetComponent<Player_stats>().Hit();
                size = 0;
                Dead();
            }
            if(other.tag == "Doge"){
                Debug.Log("Hit doge");
                speed = 6;
                other.GetComponent<Doge>().Dead();
            }
            if(other.tag == "Bullet"){
                other.gameObject.SetActive(false);
                Dead();
            }
        }
    }

    public void SetSize(int newSize){
        size = newSize;
        transform.localScale = new Vector3(1+size,1+size,1+size);
    }

    public void Dead(){
        if(size == 0){
            gameObject.GetComponent<AudioSource>().Play();
            dead = true;
            particle.SetActive(true);
            rock.SetActive(false);
            if(!player){
                poolDoge.barell = gameObject.transform;
                poolDoge.Shoot();
            }
        }else{
            size--;
            SetSize(size);
            speed-=2;
        }
    }
}
