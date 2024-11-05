using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireflower : MonoBehaviour, IPickup
{
    public void Pickup(GameObject player)
    {
        PlayerController pc = player.GetComponent<PlayerController>();
        pc.isBig = false;
        pc.isFire = true;
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
