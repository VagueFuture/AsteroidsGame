using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_objects : MonoBehaviour
{
   private Transform parent;
   private int pool_El_Number = 0;

   public GameObject prefab;
   public int object_count = 10;

   public Transform barell;

   private GameObject[] pool;
    void Start()
    {
        parent = transform;

        pool = new GameObject[object_count];

        for(int i=0;i<object_count; i++){
            pool[i] = Instantiate(prefab,transform.position,transform.rotation,parent);
            pool[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot(int power = 100){
        GameObject obj = parent.GetChild(pool_El_Number).gameObject;
        obj.SetActive(true);
        obj.transform.position = barell.position;
        obj.transform.rotation = barell.rotation;
        if(obj.GetComponent<Rigidbody>() != null)
            obj.GetComponent<Rigidbody>().AddForce(-transform.forward*power);
        pool_El_Number++;
        if(pool_El_Number > object_count-1)
            pool_El_Number = 0;
    }
}
