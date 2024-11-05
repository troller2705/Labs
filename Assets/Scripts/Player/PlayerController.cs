using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
[RequireComponent(typeof(GroundCheck))]
public class PlayerController : MonoBehaviour
{
    private int _lives;

    public int lives
    {
        get => _lives;
        set
        {
            if (value > 0)
            {

            }
            if (_lives > value)
            {

            }
            _lives = value;
            Debug.Log($"{_lives} lives left");
        }
    }
    
    private int _score;

    public int score
    {
        get => _score;
        set
        {
            if (value > 0) return;

            _score = value;
            Debug.Log($"Current score: {_score}");
        }
    }

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
    public bool isCrouched = false;

    //Ground Check Vars
    public bool isGrounded = false;

    //Power-Up Vars
    public bool isFire = false;
    public bool isBig = false;

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

        //Sprite Flipping
        if (hInput != 0) sr.flipX = (hInput < 0);

        //inputs for firing and jump attack
        if (Input.GetButtonDown("Fire1") && isGrounded && isFire) anim.SetTrigger("fire");
        if (Input.GetKeyDown("s") && !isGrounded && isBig) anim.SetTrigger("jumpAttack");
        if (Input.GetKeyDown("s") && isGrounded && (isBig || isFire)) isCrouched = true;
        if (Input.GetKeyUp("s")) isCrouched = false;

        if (!isCrouched)
        {
            rb.velocity = new Vector2(hInput * speed, rb.velocity.y);
        }

        anim.SetFloat("speed", Mathf.Abs(hInput));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isCrouched", isCrouched);
        anim.SetBool("isFire", isFire);
        anim.SetBool("isBig", isBig);
    }

    void CheckIsGrounded()
    {
        if (!isGrounded)
        {
            if (rb.velocity.y <= 0) isGrounded = gc.IsGrounded();
        }
        else isGrounded = gc.IsGrounded();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickup curPickup = collision.gameObject.GetComponent<IPickup>();
        if (curPickup != null)
        {
            curPickup.Pickup(gameObject);
        }
    }
}
