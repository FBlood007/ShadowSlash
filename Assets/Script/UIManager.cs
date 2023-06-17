using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //private variable which refers to itself
    private static UIManager instance;
    public static UIManager Instance
    {

        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }

            return instance;
        }
    }

    public static int gemCount = 0;
    public TextMeshProUGUI gemText;

    [SerializeField]
    private Transform lifeParent;

    [SerializeField]
    private GameObject lifePrefab;

    private Stack<GameObject> lives = new Stack<GameObject>();

    private void Start()
    {
        gemCount = 0;
    }
    public static void AddGem()
    {
        gemCount++;

    }
    public void Update()
    {
        gemText.text =  gemCount.ToString();
    }

    public void AddLife(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            lives.Push(Instantiate(lifePrefab, lifeParent));
        }
    }

    public void RemoveLife()
    {
        Destroy(lives.Pop());
    }
}
