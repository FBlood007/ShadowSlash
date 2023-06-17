using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //private variable which refers to itself
   /* private static UIManager instance;
    public static UIManager Instance { 
        
        get {
            if(instance == null)
            {
              instance = FindObjectOfType<UIManager>();
            }
            
            return instance; }
    }*/

    public static int gemCount = 0;

  
    public TextMeshProUGUI gemText;

    public static void AddGem()
    {
        gemCount++;

    }
    public void Update()
    {
        gemText.text = "" + gemCount;
    }
}
