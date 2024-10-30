using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMove : MonoBehaviour
{   
    private float vertical;
    private float speed = 5f;
    private bool isLadderOrRope;
    private bool isClimbing;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator Ani;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Ani =  GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get vertical input for climbing
        vertical = Input.GetAxis("Vertical");

        // If the player is on a ladder or rope and presses the vertical axis, set climbing to true
        if(isLadderOrRope && Mathf.Abs(vertical) > 0f) 
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        // Climbing logic
        if(isClimbing)
        {
            rb.gravityScale = 0f; // Disable gravity while climbing
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed); // Move vertically based on input
        }
        else 
        {
            rb.gravityScale = 4f; // Restore gravity when not climbing
        }
    }

    // Detect entering a ladder or rope area
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ladder") || other.CompareTag("Rope"))
        {
            isLadderOrRope = true;
            Ani.SetBool("Lader",true);
        }
    }

    // Detect exiting a ladder or rope area
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Ladder") || other.CompareTag("Rope"))
        {
            isLadderOrRope = false;
            isClimbing = false;
             Ani.SetBool("Lader",false);
        }
    }
}
