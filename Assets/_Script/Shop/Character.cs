using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character 
{
    public string name;//name for the character skin
    public int price;//price of the skin 
    public bool isUnlocked;//stores boolean value to check if skin is locked or unlocked
    public Sprite characterSprite;//sprite of the character
    public Material swordMaterial;//material of the sword
    public Color attackColor;//stores color of the player range attack

}
