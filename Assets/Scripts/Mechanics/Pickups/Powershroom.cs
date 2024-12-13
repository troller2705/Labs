using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powershroom : MonoBehaviour, IPickup
{
    public AudioClip pickupSound;
    SpriteRenderer sr;
    AudioSource audioSource;

    public void Pickup(GameObject player)
    {
        PlayerController pc = player.GetComponent<PlayerController>();
        if (!pc.isFire)
        {
            pc.isBig = true;
        }
        sr.enabled = false;
        audioSource.PlayOneShot(pickupSound);
        Destroy(gameObject, pickupSound.length);
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        audioSource.outputAudioMixerGroup = GameManager.Instance.SFXGroup;
    }
}
