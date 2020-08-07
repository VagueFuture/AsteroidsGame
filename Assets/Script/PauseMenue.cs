using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenue : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenueUi;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Cancel")){
            if(gamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame(){
        pauseMenueUi.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void ResumeGame(){
        pauseMenueUi.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void RestartGame(){
        pauseMenueUi.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.sceneCount);
    }

    public void NextLevll(){
        pauseMenueUi.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMenue(){
        Lvls_data data = DataHolder.Prefab;
        data.complite = true;
        DataHolder.Prefab = data;
        pauseMenueUi.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    

}
