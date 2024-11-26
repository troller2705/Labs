using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IPickup
{
    public void Pickup(GameObject player)
    {
        PlayerController pc = player.GetComponent<PlayerController>();
        GameManager.Instance.score++;
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
