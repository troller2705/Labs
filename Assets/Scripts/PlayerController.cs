using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
[RequireComponent(typeof(GroundCheck))]
public class PlayerController : MonoBehaviour
{
    //Component Refs
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    GroundCheck gc;

    //Movement Vars
    [Range(5f, 10f)]
    public float speed = 5.5f;
    [Range(3f, 10f)]
    public float jump = 8.0f;

    //Ground Check Vars
    public bool isGrounded = false; // To check if the player is on the ground

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        gc = GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curPlayingClips = anim.GetCurrentAnimatorClipInfo(0);
        CheckIsGrounded();

        float hInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2 (hInput * speed, rb.velocity.y);

        if (curPlayingClips.Length > 0)
        {
            if (!(curPlayingClips[0].clip.name == "Fire"))
            {
                rb.velocity = new Vector2(hInput * speed, rb.velocity.y);
            }
        }

        //Sprite Flipping
        if (hInput != 0) sr.flipX = (hInput < 0);

        //inputs for firing and jump attack
        if (Input.GetButtonDown("Fire1") && isGrounded) anim.SetTrigger("fire");
        if (Input.GetButtonDown("Fire1") && !isGrounded) anim.SetTrigger("jumpAttack");

        anim.SetFloat("speed", Mathf.Abs(hInput));
        anim.SetBool("isGrounded", isGrounded);
    }

    void CheckIsGrounded()
    {
        if (!isGrounded)
        {
            if (rb.velocity.y <= 0) isGrounded = gc.IsGrounded();
        }
        else isGrounded = gc.IsGrounded();
    }
}
