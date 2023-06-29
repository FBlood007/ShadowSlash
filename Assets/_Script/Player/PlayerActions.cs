using System.Collections;
using UnityEngine;

public class PlayerActions : MonoBehaviour 
{ 

   PlayerMovement player;

    //this function is used to reduce the live when player takes hit
    void Start()
    {
           player = PlayerMovement.Instance;   
    }

    //function is used to check if the player is hit and to remove the life
    public void TakeHit()
    {
      
        if (!player.isImmortal)
        {
            if (player.life >= 0)
            {
                AudioManager.Instance.PlaySound("PlayerHurt");
                player.StartCoroutine(Immortality());
                AnimationHandling.Instance.ChangeAnimationState("PlayerHurt");
                if (player.life > 0)
                {
                    UIManager.Instance.RemoveLife();
                }
                player.life--;
               
            }
            }
    }

    //used to show blink effect when player takes damage 
    private IEnumerator Blink()
    {
        while (player.isImmortal)
        {
            for(int i = 0; i < player.SpriteRenderers.Length; i++)
            {
                player.SpriteRenderers[i].enabled = false;
            }
            yield return new WaitForSeconds(0.2f);
            for (int i = 0; i < player.SpriteRenderers.Length; i++)
            {
                player.SpriteRenderers[i].enabled = true;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    //function is used to make player immortal for some time when he takes damage
    private IEnumerator Immortality()
    {
        player.isImmortal = true;
        player.StartCoroutine(Blink());
        yield return new WaitForSeconds(player.ImmortalityTime);
        player.isImmortal = false;
    }

}
