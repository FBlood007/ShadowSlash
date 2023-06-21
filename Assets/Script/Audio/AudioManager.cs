using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private void Awake() => Instance = this;
   
    [SerializeField]private Sounds[] sounds;

    void Start()
    {   
        //looping through the sound tracks added to the audiomanager script
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
        }
        if(SceneManager.GetActiveScene().name == "Level_1")
        {
            PlaySound("Level1");
        }
        if(SceneManager.GetActiveScene().name == "MenuScreens")
        {
            PlaySound("MainMenu");
        }
    }
    //fuction is used to play the sound by taking string type parameter
    public void PlaySound(string name)
    {
        foreach (Sounds s in sounds)
        {
            if (s.name == name)
                s.source.Play();
        }
    }
    public void ButtonSound()
    {
        PlaySound("Button");
    }
}