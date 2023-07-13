using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //public static PlayerManager Instance;//Instance of Player Manager
    public static int numberOfOrbs;

    public CharacterDatabase characterDB;
    public SpriteRenderer characterSprite;
    private int selectedOption = 0;
//Animator animator;

    private void Awake()
    {
        numberOfOrbs = PlayerPrefs.GetInt("NumberOfOrbs",0);
       /* if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }*/

    }

    private void Start()
    {
        AnimationHandling.Instance.ChangeAnimationState("PlayerIdle");
        if (!PlayerPrefs.HasKey("SelectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
    }


    public void ResetGame()
    {
        //PlayerPrefs.DeleteAll();
        numberOfOrbs = 0;
    }

    public void NextOption()
    {
        //Debug.Log(Time.timeScale);
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
        UpdateCharacter(selectedOption);
    }

    //function updates the sprite and material of the character
    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        characterSprite.sprite = character.characterSprite;
        characterSprite.material = character.swordMaterial;
    }

    //gets the index of the selected option of character
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("SelectedOption");
    }

    //saves the last selected option
    public void Save()
    {
        PlayerPrefs.SetInt("SelectedOption",selectedOption);
    }

}
