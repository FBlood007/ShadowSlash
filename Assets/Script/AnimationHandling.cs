using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandling : MonoBehaviour
{
    public static Animator animator;
    private static string currentState; //checks current state of animation

    // Start is called before the first frame update
    void Start()
    {
     animator = GetComponent<Animator>();
    }

    public static void  ChangeAnimationState(string newState)
    {
        //This will stop the same animation from interruting itself
        if (currentState == newState)
            return;
        //play the animation
        animator.Play(newState);
    }
}
