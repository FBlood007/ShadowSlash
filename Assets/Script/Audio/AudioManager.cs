using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField]private Sounds[] sounds;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
   
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
        if (SceneManager.GetActiveScene().name == "MenuScreens")
        {
            AudioManager.Instance.PauseSound("Level1");
            AudioManager.Instance.PlaySound("MainMenu");
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
    public void PauseSound(string name) {
        foreach (Sounds s in sounds)
        {
            if (s.name == name)
                s.source.Pause();
        }
    }
    public void ButtonSound()
    {
        PlaySound("Button");
    }

    
}