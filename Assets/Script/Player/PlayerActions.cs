using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private PlayerMovement player;

    public PlayerActions(PlayerMovement player)
    {
        this.player = player;   
    }

    public static void TakeHit()
    {
        if (PlayerMovement.life  > 0 )
        {
        AnimationHandling.ChangeAnimationState("PlayerHurt");
        PlayerMovement.life--;
        UIManager.Instance.RemoveLife();

        }
        else
        {
            AnimationHandling.ChangeAnimationState("PlayerDeath");
        }
    }

}
