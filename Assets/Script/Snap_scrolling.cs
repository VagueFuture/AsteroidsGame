using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Snap_scrolling : MonoBehaviour
{
    [Range(1,50)]
    [Header("Controllers")]
    public int count;
    public GameObject prefab;
    public List<Lvls_data> sObj = new List<Lvls_data>();
    private GameObject[] pans;
    void Start()
    {
        pans = new GameObject[count];
        int x=-1000;
        for(int i = 0;i<count;i++){
            pans[i] = Instantiate(prefab,transform,false);
            pans[i].transform.localPosition = new Vector2(pans[i].transform.position.x+x,0);
            pans[i].GetComponent<SetDataToLvl>().data = sObj[i];
            x+=450;
        }
        createSaveFile();
    }

    public void createSaveFile(){

        /*
        if(!Directory.Exists(Application.persistentDataPath+"Settings")){
            Directory.CreateDirectory("Settings");
        }
                     
        if(!File.Exists(Application.persistentDataPath+"Settings/Save.s")){
            File.Create(Application.persistentDataPath+"Settings/Save.s");
            CreateFile();
        }else{*/
           // string[] readedLines = File.ReadAllLines(Application.persistentDataPath+"Settings/save.s");
          //  if(PlayerPrefs.GetString("0")==null){//if(readedLines.Length<count){
          ///      CreateFile();
          //  }
        //}

    }

   /* public void CreateFile(){
        string[] str = new string[count];
            for(int i = 0;i<count;i++){
                str[i] = "false";
                PlayerPrefs.SetString(i+"",str[i]);
            }
    }
*/
}
