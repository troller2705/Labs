using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField, Range(0.01f, 1)] private float groundCheckRadius = 0.02f;
    [SerializeField] private LayerMask groundCheckLayerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
