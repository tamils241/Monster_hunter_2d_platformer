using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elvetor_Patrol : MonoBehaviour
{
    public Transform[] waypoints;      // Array of waypoints for the object to patrol
    public float speed = 2f;           // Movement speed of the object
    private int currentWaypointIndex = 0; // Index of the current waypoint

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        // Check if there are any waypoints set
        if (waypoints.Length == 0) return;

        // Move the object towards the current waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Check if the object has reached the waypoint
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Go to the next waypoint
            currentWaypointIndex++;
            
            // If we reached the last waypoint, loop back to the first one
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}