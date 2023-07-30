using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject levelComplete;
    public GameObject GameComplete;
    public GameObject Joystick;
    public GameObject GameOver;
    public static UIManager Instance;
    //private void Awake() => Instance = this;

     private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public int ObjectiveCount = 0;//variable to keep the count of the objective
    public TextMeshProUGUI OrbCountText;//text of orb
    public TextMeshProUGUI levelCompleteOrbCount;//Count to show orb when level completed
    public TextMeshProUGUI Objective;
    public int orbCollectedInLevel = 0;

    [SerializeField]
    private Transform lifeParent;

    [SerializeField]
    private GameObject lifePrefab;

    private Stack<GameObject> lives = new Stack<GameObject>();

    public GameObject RightButton;
    public GameObject LeftButton;
    public GameObject JumpButton;
    public GameObject AttackButton;
    public GameObject Controls;


    private void Start()
    {
        SystemCheck();
        Time.timeScale = 1f;
        ObjectiveCount = 0;
        if(SceneManager.GetActiveScene().name == "Level_1")
        {
            Objective.text = "Kill all Monsters";
            //Objective.text = "Collect all Orbs";
        }
        if (SceneManager.GetActiveScene().name == "Level_2")
        {
            Objective.text = "Kill all Monsters";
        }

    }
    public void AddObjectiveCount()
    {
        ObjectiveCount++;
        //Debug.Log("Enemy killed "+ ObjectiveCount);
    }

    public void NoOfOrbCollectedPerLevel()
    {
        orbCollectedInLevel++;
    }


    public void Update()
    {
        OrbCountText.text = PlayerManager.numberOfOrbs.ToString();

        if (SceneManager.GetActiveScene().buildIndex == 1 && ObjectiveCount == 5)
        {
            //Debug.Log(orbCollectedInLevel + "Level Completed with this much of orbs");
            levelCompleteOrbCount.text = orbCollectedInLevel.ToString();
            levelComplete.SetActive(true);
            Joystick.SetActive(false);
            Time.timeScale = 0;
            UnlockNewLevel();
        }
        if (SceneManager.GetActiveScene().buildIndex == 2 && ObjectiveCount == 4)
        {
            levelCompleteOrbCount.text = orbCollectedInLevel.ToString();
            levelComplete.SetActive(true);
            Joystick.SetActive(false);
            Time.timeScale = 0;
            UnlockNewLevel();
        }
        if (SceneManager.GetActiveScene().buildIndex == 3 && ObjectiveCount == 1)
        {
            
            GameComplete.SetActive(true);
            Joystick.SetActive(false);
            Time.timeScale = 0;
            //UnlockNewLevel();
        }
        if (PlayerMovement.Instance.life == 0)
        {
            Debug.Log(PlayerMovement.Instance.life + " no if lives");
            GameOver.SetActive(true);
            Joystick.SetActive(false);
        }
    }
   
    //function to add life in the UI
    public void AddLife(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            lives.Push(Instantiate(lifePrefab, lifeParent));
        }
    }

    //function to remove life image when player takes damage
    public void RemoveLife()
    {
        Destroy(lives.Pop());
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
    public void SystemCheck()
    {
        if(UnityEngine.Device.SystemInfo.deviceType == DeviceType.Desktop)
        {
           RightButton.SetActive(false);
           LeftButton.SetActive(false);
           JumpButton.SetActive(false);
           AttackButton.SetActive(false);
           Controls.SetActive(true);
        }

    }

    public void UnlockNewLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("UnlockedLevel"))
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLevel + 1);

        }
        Debug.Log("Level "+ PlayerPrefs.GetInt("UnlockedLevel")+" Unlocked");
    }


}
