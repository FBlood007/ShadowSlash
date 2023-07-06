using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreenPopUp : MonoBehaviour
{
    public GameObject pauseBox;//pause popup gameobject
    public GameObject exitBox;//exit popup gameobject
    public GameObject settingPopup;//setting popup gameobject
    void Start()
    {
        settingPopup.SetActive(false);
    }

    //function to lock the time frame when game is paused
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    //function to resume the time frame when game is resumed
    public void Resume()
    {
        Time.timeScale = 1f;
    }

    //reload the scene when restarted
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Music()
    {

    }

    //function is for menu button to navigate player to the main menu
    public void MainMenuButton()
    {
        //UIManager._gemCount = 0;
        AudioManager.Instance.PauseSound("Level2");
        AudioManager.Instance.PauseSound("Level1");
        AudioManager.Instance.PlaySound("MainMenu");
        SceneManager.LoadScene("MenuScreens");
    }

    public void MuteAudio(bool mute)
    {
        if (mute)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }


}
