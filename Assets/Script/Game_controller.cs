using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Game_controller : MonoBehaviour
{

    [Range(1,50)]
    public int doge_count_to_win = 10;
    public int doge_count_lost_to_losing = -1;
    public float speedSpawn;
    [Range(10,50)]
    public int maxAsteroidSpeed = 10;
    public int lostDoge;
    public Pool_objects poolAsteroids;
    public Transform spawner;
    private float _timer;
    public Text doge_count_text;
    public Text Live_count_text;
    private Player_stats playerStats;

    public GameObject winPanel;
    public GameObject losingPanel;
    void Start()
    {
        Time.timeScale = 1f;
        _timer = speedSpawn;
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_stats>();
        if(DataHolder.Prefab != null){
            Lvls_data data = DataHolder.Prefab;
            doge_count_to_win = data.doge_count_to_win;
            doge_count_lost_to_losing = data.doge_count_lost_to_losing;
            speedSpawn = data.speedSpawn;
            maxAsteroidSpeed = data.maxAsteroidSpeed;
        }
    }

    void FixedUpdate()
    {
        _timer+=Time.deltaTime;
        if(_timer>speedSpawn){
            int x = Random.Range(-23,11);
            spawner.position = new Vector3(x,spawner.position.y,spawner.position.z);
            int speed = Random.Range(5,maxAsteroidSpeed);
            poolAsteroids.barell = spawner;
            poolAsteroids.Shoot();
            _timer = 0;
        }

        if(playerStats.live<=0){
            losingPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if(playerStats.GetDogeCount()>=doge_count_to_win){
            winPanel.SetActive(true);
            Time.timeScale = 0f;
            Save();
        }

        if(doge_count_lost_to_losing!= -1 && doge_count_lost_to_losing<lostDoge){
            losingPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        doge_count_text.text = "Dog count \n"+playerStats.GetDogeCount();
        Live_count_text.text = "Live count \n"+playerStats.live;
    }

     public void Save()
    {
        //string[] readedLines = File.ReadAllLines(Application.persistentDataPath+"Settings/save.s");
        Lvls_data data = DataHolder.Prefab;
        PlayerPrefs.SetString(data.numberLvl+"","true");
        //readedLines[i] = "true";
        
        
    }

}
