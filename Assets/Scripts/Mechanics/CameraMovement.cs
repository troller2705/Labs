using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float minXValue;
    public float maxXValue;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = GameManager.Instance.PlayerInstance.transform;

        if (!playerTransform) return;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(playerTransform.position.x, minXValue, maxXValue);
        transform.position = pos;
    }
}
