using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    void Start()
    {
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
