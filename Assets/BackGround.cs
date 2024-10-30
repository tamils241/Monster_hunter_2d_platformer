using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
 /*public Transform player;  // Reference to the player's transform
  private Vector3 offset;   // Offset distance between the player and background

    void Start()
    {
        // Calculate and store the offset value by getting the distance between the player's position and background's position.
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Set the position of the background's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.position + offset;
    }
}*/
    public Transform player;  // Reference to the player's transform
    public float parallaxEffectMultiplier;  // How much the background moves relative to the player

    private Vector3 lastPlayerPosition;  // Store the player's position in the previous frame

    void Start()
    {
        lastPlayerPosition = player.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = player.position - lastPlayerPosition;
        transform.position += deltaMovement * parallaxEffectMultiplier;
        lastPlayerPosition = player.position;
    }
}


