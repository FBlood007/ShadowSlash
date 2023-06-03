using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject settings;
    public GameObject levels;

    void Start()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
        levels.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (mainMenu.activeInHierarchy)
            {
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

    public void Play()
    {
        mainMenu.SetActive(false);
        settings.SetActive(false);
        levels.SetActive(true);
       
    }
    public void Setting()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
        levels.SetActive(false);
    }
    public void LevelSelect(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
