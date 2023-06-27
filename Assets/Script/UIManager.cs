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

    public int OrbCount = 0;//variable to keep the count of the orb
    public TextMeshProUGUI OrbText;//text of orb
    public TextMeshProUGUI levelCompleteOrbCount;//Count to show orb when level completed

    [SerializeField]
    private Transform lifeParent;

    [SerializeField]
    private GameObject lifePrefab;

    private Stack<GameObject> lives = new Stack<GameObject>();

  
    private void Start()
    {
        Time.timeScale = 1f;
        OrbCount = 0;
        
    }
    public void AddOrb()
    {
        OrbCount++;

    }
    public void Update()
    {
        
        OrbText.text =  OrbCount.ToString() + "/7";//sets the no. of orb collected in the TMP

        if (SceneManager.GetActiveScene().name == "Level_1" && OrbCount == 7)
        {
            levelCompleteOrbCount.text = OrbCount.ToString();
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   
}
