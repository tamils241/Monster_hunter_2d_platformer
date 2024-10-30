

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;


public class Flip_Script : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    [SerializeField]private float jumpForce = 15f;
    private float Red_increas = 0 ,Yellow_increas = 0 ,Green_increas = 0 ,Pink_increas = 0 ;
    public TMP_Text Red_text ,Yellow_text ,Green_text,Pink_text ;
    public Button Rest_button;
    public Animator Ani;
    public SpriteRenderer SpriteRenderer;
    private BoxCollider2D Collider2D;
    public LayerMask groundMask;
    private bool isAttacking = false;
    public AudioSource Audio;
    public AudioClip fruits_Sound;
    public AudioClip player_Attack_Sound;
    public Enemy_Health Enemy_Health;
    public float minX = -7f; // Minimum x position (left boundary)
    public float maxX = 96f;  // Maximum x position (right boundary)


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Collider2D = GetComponent<BoxCollider2D>();
        Ani = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handling movement
        float moveX = Input.GetAxis("Horizontal");
        Vector2 temp = transform.position;

        if (moveX > 0)
        {
            temp.x += speed * Time.deltaTime;
            SpriteRenderer.flipX = false;
            Ani.SetBool("Run", true);
        }
        else if (moveX < 0)
        {
            temp.x -= speed * Time.deltaTime;
            SpriteRenderer.flipX = true;
            Ani.SetBool("Run", true);
        }
        else if (moveX == 0)
        {
            Ani.SetBool("Run", false);
        }
         temp.x = Mathf.Clamp(temp.x, minX, maxX);
         transform.position = temp;


        // Jumping logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
            Ani.SetTrigger("Jumping");
        }

        

        // Attacking logic (Left mouse button pressed)
        if (Input.GetMouseButtonDown(0))
        {
            Ani.SetTrigger("Attack");
            isAttacking = true;
            Audio.PlayOneShot(player_Attack_Sound);
           // SpawnBullet();
        }
    }

    // Method to check if the player is on the ground
    bool isGrounded()
    {
        return Physics2D.BoxCast(Collider2D.bounds.center, Collider2D.bounds.size, 0, Vector2.down, 0.1f, groundMask);
    }

    // Spawning bullet
    /*void SpawnBullet()
    {
     Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);    
    }*/

    // Handling collision with various fruits items
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Red"))
        {
            Destroy(other.gameObject);
            Red_increas++;
            Red_text.text = "x" + Red_increas;
            Audio.PlayOneShot(fruits_Sound);
        }
        if (other.gameObject.CompareTag("Yellow"))
        {
            Destroy(other.gameObject);
            Yellow_increas++;
            Yellow_text.text = "x" + Yellow_increas;
            Audio.PlayOneShot(fruits_Sound);
        }
        if (other.gameObject.CompareTag("Green"))
        {
            Destroy(other.gameObject);
            Green_increas++;
            Green_text.text = "x" + Green_increas;
            Audio.PlayOneShot(fruits_Sound);
        }
        if (other.gameObject.CompareTag("Pink"))
        {
            Destroy(other.gameObject);
            Pink_increas++;
            Pink_text.text = "x" + Pink_increas;
            Audio.PlayOneShot(fruits_Sound);
        }
        
        if (other.gameObject.CompareTag("Enemy"))
      {
        Debug.Log("Enemy isTrigger");
        // Ensure that the enemy has a script with a TakeDamage method
       // Enemy_Health enemyHealth = other.GetComponent<Enemy_Health>();

        if (isAttacking == true)
        {
          Enemy_Health.TakeDamage_Enemy(1);  // Example: deal 1 damage to the enemy
        }
            
        
        else
        {
            Debug.LogError("Enemy does not have an EnemyHealth component!");
        }
    }
        
    }

    // Reset the game by reloading the current scene
   
}
