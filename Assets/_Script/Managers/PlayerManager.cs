using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    //public static PlayerManager Instance;//Instance of Player Manager
    public static int numberOfOrbs;

    public CharacterDatabase characterDB;
    public SpriteRenderer characterSprite;
    private int selectedOption = 0;
    private int SkinCost;
    public Color selectedAttackColor;
    public TextMeshProUGUI orbCost;
    public TextMeshProUGUI TotalOrbCount;
    public TextMeshProUGUI PopupText;
    public GameObject lockedButton;
    public GameObject selectButton;
    public GameObject CostBoard;
    //Animator animator;

    private void Awake()
    {
        numberOfOrbs = PlayerPrefs.GetInt("NumberOfOrbs",0);
        TotalOrbCount.text = numberOfOrbs.ToString();
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
        //AnimationHandling.Instance.ChangeAnimationState("PlayerIdle");
        if (!PlayerPrefs.HasKey("SelectedOption"))
        {
            selectedOption = 0;
            characterDB.SetSkinLockForFirstLoad();

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
        orbCost.text = character.price.ToString();
        SkinCost = character.price;
        selectedAttackColor = character.attackColor;
        if (character.isUnlocked)
        {
            CostBoard.SetActive(false);
            selectButton.SetActive(true);
            lockedButton.SetActive(false);

        }
        else
        {
            CostBoard.SetActive(true);
            selectButton.SetActive(false);
            lockedButton.SetActive(true);
        }
    }

    //gets the index of the selected option of character
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("SelectedOption");
    }

    //saves the last selected option
    public void Save()
    {
        PopupText.text = "Selected";
        PlayerPrefs.SetInt("SelectedOption",selectedOption);
    }

    public void SkinUnlock()
    {
        if(SkinCost > numberOfOrbs)
        {
            Debug.Log("U dont have sufficient orbs");
            PopupText.text = "Insufficient Orbs";
        }
        else
        {
            PopupText.text = "Obtained new skin";
            PlayerPrefs.SetInt("NumberOfOrbs", numberOfOrbs-SkinCost);
            numberOfOrbs -= SkinCost;
            TotalOrbCount.text = numberOfOrbs.ToString();
            characterDB.SetCharacter(true, selectedOption);
            CostBoard.SetActive(false);
            selectButton.SetActive(true);
            lockedButton.SetActive(false);
            
        }
    }
    
}
