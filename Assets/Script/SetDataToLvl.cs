using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class SetDataToLvl : MonoBehaviour
{
    public Lvls_data data;

    public Text nameLevl,complex,descript,complite;
    public GameObject panel_lock;
    public bool compl,acc;
    void Start()
    {
        compl = data.complite;
        acc = data.access;
        reload();
        load();
    }

    public void reload()
    {
        if(data!= null){
            nameLevl.text = data.lvlName;
            descript.text = data.description;
            complex.text = data.complexity;
            if(compl){
                complite.text = "Complete";
            }else{
                complite.text = "Not complete";
            }
            panel_lock.SetActive(!acc);
        }else{
            Debug.Log("Miss Data");
        }
    }

    public void LoadScene(){
        DataHolder.Prefab = data;
        SceneManager.LoadScene(1);
    }

    public void load()
    {   
        string loadstr;
        loadstr = PlayerPrefs.GetString(data.numberLvl+"");
        if(loadstr!="")
            compl = Convert.ToBoolean(loadstr);
        if(data.numberLvl!=0){
            loadstr = PlayerPrefs.GetString((data.numberLvl-1)+"");
            if(loadstr != "")
                acc = Convert.ToBoolean(PlayerPrefs.GetString((data.numberLvl-1)+""));
        }
        //string[] readedLines = File.ReadAllLines(Application.persistentDataPath+"Settings/save.s");
       // if(readedLines.Length == 0)
          //  Debug.Log("Empty");

       // if(readedLines.Length != 0)
      //  {
         //   for(int i=0;i<readedLines.Length;i++){
          //      Debug.Log(readedLines[i]);
           //     if(i==data.numberLvl-1 && data.numberLvl!=0){
           //         acc = Convert.ToBoolean(readedLines[i]);
           //     }
           //     if(i==data.numberLvl)
            //        compl = Convert.ToBoolean(readedLines[i]);
           // }
       // }
        reload();
    }
}
