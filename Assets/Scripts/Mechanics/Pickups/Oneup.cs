using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oneup : MonoBehaviour, IPickup
{
    public void Pickup(GameObject player)
    {
        PlayerController pc = player.GetComponent<PlayerController>();
        GameManager.Instance.lives++;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
