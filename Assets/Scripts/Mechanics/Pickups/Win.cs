using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour, IPickup
{
    public void Pickup(GameObject player)
    {
        SceneManager.LoadScene("Win");
    }
}
