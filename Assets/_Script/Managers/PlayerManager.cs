using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;//Instance of Player Manager
    public static int numberOfOrbs;

    public CharacterDatabase characterDB;
    public SpriteRenderer characterSprite;
    private int selectedOption = 0;

    private void Awake()
    {
        
        numberOfOrbs = PlayerPrefs.GetInt("NumberOfOrbs",0);
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {
        UpdateCharacter(selectedOption);
    }

    private void Update()
    {
        Debug.Log(numberOfOrbs);

    }

    public void ResetGame()
    {
        //PlayerPrefs.DeleteAll();
        numberOfOrbs = 0;
    }

    public void NextOption()
    {
        selectedOption++;
        if(selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0; 
        }

        UpdateCharacter(selectedOption);
    }

    public void BackButton()
    {
        selectedOption--;
        if(selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;    
        }
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        characterSprite.sprite = character.characterSprite;

    }

}
