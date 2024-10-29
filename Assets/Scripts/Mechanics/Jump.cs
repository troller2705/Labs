using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerController pc;

    [SerializeField] private float jumpHeight = 5;
    [SerializeField] private float jumpFallForce = 50;

    float timeHeld;
    float maxHoldTime = 0.5f;
    float calculatedJumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
