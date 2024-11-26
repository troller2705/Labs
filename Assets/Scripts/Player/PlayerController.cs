using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
[RequireComponent(typeof(GroundCheck), typeof(Jump))]
public class PlayerController : MonoBehaviour
{
    //Component Refs
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    GroundCheck gc;
    Jump jmp;

    //Movement Vars
    [Range(5f, 10f)]
    public float speed = 5.5f;
    [Range(3f, 10f)]
    public float bounce = 10.0f;
    public bool jumpAttack = false;
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
        jmp = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curPlayingClips = anim.GetCurrentAnimatorClipInfo(0);
        CheckIsGrounded();

        float hInput = Input.GetAxis("Horizontal");

        //Sprite Flipping
        if (hInput != 0) sr.flipX = (hInput < 0);

        if (isGrounded)
        {
            jumpAttack = false;
        }

        //inputs for firing and jump attack
        if (Input.GetButtonDown("Fire1") && isGrounded && isFire) anim.SetTrigger("fire");
        if (Input.GetKeyDown("s") && !isGrounded && isBig)
        {
            anim.SetTrigger("jumpAttack");
            jumpAttack = true;
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if ((rb.velocity.y < 0) && (rb.position.y > collision.gameObject.transform.position.y))
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(1);
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            }
            else
            {
                GameManager.Instance.lives--;
            }
        }
    }
}
