using System.Collections;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private PlayerMovement player;
    GameObject playerAction;

    private void Awake()
    {

        playerAction = GameObject.FindGameObjectWithTag("Player");
        player = playerAction.GetComponent<PlayerMovement>();

    }
    public PlayerActions(PlayerMovement player)
    {
        this.player = player;
    }
    //this function is used to reduce the live when player takes hit
    public void TakeHit()
    {
        if (!PlayerMovement.isImmortal)
        {
            if (PlayerMovement.life >= 0)
            {
               player.StartCoroutine(Immortality());
                AnimationHandling.ChangeAnimationState("PlayerHurt");
                if (PlayerMovement.life > 0)
                {
                    UIManager.Instance.RemoveLife();
                }
                PlayerMovement.life--;
               
            }
            }
    }

    //used to show blink effect when player takes damage 
    private IEnumerator Blink()
    {
        while (PlayerMovement.isImmortal)
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
        PlayerMovement.isImmortal = true;
        player.StartCoroutine(Blink());
        yield return new WaitForSeconds(player.ImmortalityTime);
        PlayerMovement.isImmortal = false;
    }


  
}
