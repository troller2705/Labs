using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerController pc;
    GroundCheck gc;

    [SerializeField, Range(2, 5)] private float jumpHeight = 5;
    [SerializeField, Range(1, 20)] private float jumpFallForce = 50;

    float timeHeld;
    float maxHoldTime = 0.5f;
    float jumpInputTime = 0;
    float calculatedJumpForce;

    bool jumpCancelled;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = rb.GetComponent<PlayerController>();
        gc = pc.GetComponent<GroundCheck>();

        calculatedJumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.isGrounded) jumpCancelled = false;
        if (Input.GetButtonDown("Jump")) jumpInputTime = Time.time;
        if (Input.GetButton("Jump")) timeHeld += Time.deltaTime;
        if (Input.GetButtonUp("Jump"))
        {
            timeHeld = 0;
            jumpInputTime = 0;
            if (rb.velocity.y < -10) return;
            jumpCancelled = true;
        }

        if (jumpInputTime != 0 && (jumpInputTime + timeHeld) < (Time.time + maxHoldTime))
        {
            if (pc.isGrounded)
            {
                jumpCancelled = false;
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, calculatedJumpForce), ForceMode2D.Impulse);
            }
        }

        if (jumpCancelled)
        {
            rb.AddForce(Vector2.down * jumpFallForce);
        }
    }
}
