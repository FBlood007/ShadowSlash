using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject settings;
    public GameObject levels;
    public TextMeshProUGUI TotalOrbCount;

    void Start()
    {
        TotalOrbCount.text = PlayerPrefs.GetInt("NumberOfOrbs", 0).ToString();
    }
    void Update()
    {
        //this statements helps when player press back button of mobile
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (mainMenu.activeInHierarchy)
            {
                PlayerPrefs.Save();
                Application.Quit();
            }
            if(settings.activeInHierarchy || levels.activeInHierarchy)
            {
                mainMenu.SetActive(true);
                settings.SetActive(false);
                levels.SetActive(false);
            }
        }    
    }



    //function to handle the level scenes here we take input as a scene name
    public void LevelSelect(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

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
