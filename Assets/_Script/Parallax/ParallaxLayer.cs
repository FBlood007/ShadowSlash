using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{

    //it takes float value to denote the distance of layer from player/camera
    //ie. if parallaxFactor is 1 then the layer will move with the player layer will be far and if its 0.1 it will be close to player
    public float parallaxFactor;
    
    //Function calculates the position of the layer with respect to factor
    public void Move(float delta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= delta * parallaxFactor;

        transform.localPosition = newPos;
    }

}
