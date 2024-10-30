using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
   public Transform[] waypoints;   // Array to hold the waypoints
    public float speed = 2f;        // Speed of the enemy movement
    private int currentWaypoint = 0; // Index to track the current waypoint
    private SpriteRenderer spriteRenderer;
    private Animator animator;      // Animator reference
    private Vector3 previousPosition; // To track previous position and calculate direction
    public bool isAttacking = false;  // Flag to trigger attack
    private float attackCooldown = 1f; // Cooldown after losing player
    private float attackCooldownTimer = 0f;
    public Transform player;  // Reference to the player object
   // public GameObject bulletPrefab;  // The bullet prefab to instantiate
    //public Transform spawnPoint;     // The point where the bullet spawns
    private AudioSource Audio;
    public AudioClip Enemy_Attack_Sound;
   

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();  // Get the Animator component
        previousPosition = transform.position; // Initialize previous position
        Audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isAttacking)
        {
            Attack();
            attackCooldownTimer = attackCooldown; // Reset cooldown when attacking
        }
        else if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime; // Countdown
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (waypoints.Length == 0) return;

        // Move the enemy towards the current waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

        // Set walking animation
        animator.SetBool("isWalking", true);
        animator.SetBool("isAttacking", false);

        // Flip the sprite based on the direction of movement
        if (transform.position.x > previousPosition.x)
        {
            spriteRenderer.flipX = false; // Facing right
        }
        else if (transform.position.x < previousPosition.x)
        {
            spriteRenderer.flipX = true; // Facing left
        }

        previousPosition = transform.position; // Update previous position for the next frame

        // Check if the enemy has reached the waypoint
        if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            // Move to the next waypoint
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }

     public void Attack()
    {
        
        // Stop walking and play attack animation
        animator.SetBool("isWalking", false);
        animator.SetBool("isAttacking", true);
        Audio.PlayOneShot(Enemy_Attack_Sound);

        // Face the player while attacking
        if (player != null)
        {
            if (player.position.x > transform.position.x)
            {
                spriteRenderer.flipX = false;  // Player is to the right
            }
            else if (player.position.x < transform.position.x)
            {
                spriteRenderer.flipX = true;  // Player is to the left
            }
        }

        // Instantiate bullet or projectile
       // Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    // You can trigger the attack from other scripts by setting isAttacking to true
    public void TriggerAttack()
    {
        isAttacking = true;
    }

    public void StopAttack()
    {
        isAttacking = false;
    }

    // Trigger attack when the player enters the collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerAttack();
        }
    }

    // Stop attacking when the player exits the collider
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAttack();
            attackCooldownTimer = attackCooldown;
        }
    }
}
