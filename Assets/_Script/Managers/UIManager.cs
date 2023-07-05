using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject levelComplete;
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
    public TextMeshProUGUI ObjectiveCountText;//text of orb
    public TextMeshProUGUI levelCompleteOrbCount;//Count to show orb when level completed
    public TextMeshProUGUI Objective;
    public int orbCollectedInLevel = 0;

    [SerializeField]
    private Transform lifeParent;

    [SerializeField]
    private GameObject lifePrefab;

    private Stack<GameObject> lives = new Stack<GameObject>();

  
    private void Start()
    {
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
        if(SceneManager.GetActiveScene().name == "Level_1")
        {
            //ObjectiveCountText.text = ObjectiveCount.ToString() + "/7";
            ObjectiveCountText.text = PlayerManager.numberOfOrbs.ToString();
        }
        else
        {
            ObjectiveCountText.text = ObjectiveCount.ToString() + "/4";
        }
         
        if (SceneManager.GetActiveScene().name == "Level_1" && ObjectiveCount == 5)
        {
            Debug.Log(orbCollectedInLevel + "Level Completed with this much of orbs");
            levelCompleteOrbCount.text = orbCollectedInLevel.ToString();
            levelComplete.SetActive(true);
            Time.timeScale = 0;
            //orbCollectedInLevel = 0;
        }
        if (SceneManager.GetActiveScene().name == "Level_2" && ObjectiveCount == 4)
        {
            levelCompleteOrbCount.text = orbCollectedInLevel.ToString();
            levelComplete.SetActive(true);
            Time.timeScale = 0;
            //orbCollectedInLevel = 0;
        }
        if(PlayerMovement.Instance.life == 0)
        {
            GameOver.SetActive(true);
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

   
}
