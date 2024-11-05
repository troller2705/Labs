using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;

    public float minXValue;
    public float maxXValue;


    // Start is called before the first frame update
    void Start()
    {
        if (playerTransform == null)
            Debug.Log("Please set player transform on camera movement");
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerTransform) return;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(playerTransform.position.x, minXValue, maxXValue);
        transform.position = pos;
    }
}
