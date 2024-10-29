using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    //Component Refs
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    //Movement Vars
    [Range(5f, 10f)]
    public float speed = 5.5f;
    [Range(3f, 10f)]
    public float jump = 8.0f;

    //Ground Check Vars
    [Range(0.01f, 0.1f)]
    public float groundCheckRadius = 0.02f;
    public bool isGrounded = true; // To check if the player is on the ground
    public LayerMask isGroundLayer;
    public Transform groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        //Ground Check Init
        GameObject newGameObject = new GameObject();
        newGameObject.transform.SetParent(transform);
        newGameObject.transform.localPosition = Vector3.zero;
        newGameObject.name = "GroundCheck";
        groundCheck = newGameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (rb.velocity.y <= 0 && !isGrounded)
        //{
        //    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);
        //}
        CheckIsGrounded();

        float hInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2 (hInput * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }

        //Sprite Flipping
        if (hInput != 0) sr.flipX = (hInput < 0); 

        anim.SetFloat("speed", Mathf.Abs(hInput));
        anim.SetBool("isGrounded", isGrounded);
    }

    void CheckIsGrounded()
    {
        if (!isGrounded)
        {
            if (rb.velocity.y <= 0) isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);
        }
        else isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);
    }
}
