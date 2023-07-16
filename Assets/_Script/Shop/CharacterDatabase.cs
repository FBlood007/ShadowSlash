using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public Character[] character;
    
    //stores the count/length of the character in the array
    public int CharacterCount
    {
        get
        {
            return character.Length;
        }
    }

    //function which returns character at specific index from the character array
    public Character GetCharacter(int index)
    {
        return character[index];    
    }
    public void SetCharacter(bool value, int index)
    {
        character[index].isUnlocked = value;
    }

    public void SetSkinLockForFirstLoad()
    {
        for(int i = 1; i < character.Length; i++)
        {
            character[i].isUnlocked = false;
        }
    }
}
