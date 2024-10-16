using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Range(5f, 10f)]
    public float speed = 5.5f;

    public float jump = 200f;

    private bool isGrounded = true; // To check if the player is on the ground

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector2 (hInput * speed, rb.velocity.y);

        if (vInput != 0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, vInput * jump);
            isGrounded = false;
        }
    }

    // Check if player is grounded
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")  // Ensure your ground objects are tagged "Ground"
        {
            isGrounded = true;
        }
    }
}
