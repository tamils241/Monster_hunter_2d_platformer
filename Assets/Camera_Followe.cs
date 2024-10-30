using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Followe : MonoBehaviour
{
   public Transform target;  // The target that the camera will follow
    public Vector3 offset;    // Offset from the target
    public float smoothSpeed = 0.125f;  // Smoothness factor

    void FixedUpdate()
    {
        // Desired position is the target position plus the offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between the current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera position to the smoothed position, preserving the original Z value for 2D
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}