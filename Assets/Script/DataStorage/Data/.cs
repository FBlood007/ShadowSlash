using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour
{
    public int level;
    public int deathCount;
    public int damageTakenCount;
    public int gemsCollected;
    public int noOfLives;
    public float[] position;

    //values defined in the constructor will be the default values when the game starts 
    //and when there is no data to load
  /*  public GameData(PlayerMovement player, UIManager uiManager)
    {
        level = player.level;
        gemsCollected = uiManager.noOfGems;
        noOfLives = player.noOfLife;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }*/

    public GameData( UIManager uiManager)
    {
    
        gemsCollected = uiManager.noOfGems;
    }
}
