using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private PlayerMovement player;


    public PlayerActions(PlayerMovement player)
    {
        this.player = player;
    }
    public void Start()
    {
    }

    public void Update()
    {
      
    }
    public static void TakeHit()
    {
       /* if (!PlayerMovement.isImmortal)
        {*/
            if (PlayerMovement.life >= 0)
            {
               // player.StartCoroutine(Immortality());
                AnimationHandling.ChangeAnimationState("PlayerHurt");
                if (PlayerMovement.life > 0)
                {
                    UIManager.Instance.RemoveLife();
                }
                PlayerMovement.life--;
               
            }
        //}
    }
    private IEnumerator Blink()
    {
        while (PlayerMovement.isImmortal)
        {
            for(int i = 0; i < player.SpriteRenderers.Length; i++)
            {
                player.SpriteRenderers[i].enabled = false;
            }
            yield return new WaitForSeconds(0.1f);
            for (int i = 0; i < player.SpriteRenderers.Length; i++)
            {
                player.SpriteRenderers[i].enabled = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    private IEnumerator Immortality()
    {
        PlayerMovement.isImmortal = true;
        player.StartCoroutine(Blink());
        yield return new WaitForSeconds(player.ImmortalityTime);
        PlayerMovement.isImmortal = false;
    }


  
}
