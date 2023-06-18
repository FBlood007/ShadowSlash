using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreenPopUp : MonoBehaviour
{
    public GameObject pauseBox;
    public GameObject exitBox;
    public GameObject settingPopup;
    void Start()
    {
        settingPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void Music()
    {

    }

    //function is for menu button to navigate player to the main menu
    public void MainMenuButton()
    {
        
        SceneManager.LoadScene("MenuScreens");
    }

   
    public void GameOver()
    {
        settingPopup.SetActive(true);
    }

}
