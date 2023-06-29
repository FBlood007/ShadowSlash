using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject levelComplete;
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
    public TextMeshProUGUI OrbText;//text of orb
    public TextMeshProUGUI levelCompleteOrbCount;//Count to show orb when level completed
    public TextMeshProUGUI Objective;
   


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
            Objective.text = "Collect all Orbs";
        }
        if (SceneManager.GetActiveScene().name == "Level_2")
        {
            Objective.text = "Kill all Monsters";
        }

    }
    public void AddObjectiveCount()
    {
        ObjectiveCount++;

    }
    public void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level_1")
        {
            OrbText.text = ObjectiveCount.ToString() + "/7";
        }
        else
        {
            OrbText.text = ObjectiveCount.ToString() + "/4";
        }
         
        if (SceneManager.GetActiveScene().name == "Level_1" && ObjectiveCount == 7)
        {
            levelCompleteOrbCount.text = ObjectiveCount.ToString();
            levelComplete.SetActive(true);
            Time.timeScale = 0;
        }
        if (SceneManager.GetActiveScene().name == "Level_2" && ObjectiveCount == 1)
        {
            levelCompleteOrbCount.text = ObjectiveCount.ToString();
            levelComplete.SetActive(true);
            Time.timeScale = 0;
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
