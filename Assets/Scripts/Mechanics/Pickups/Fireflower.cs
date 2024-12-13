using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireflower : MonoBehaviour, IPickup
{
    public AudioClip pickupSound;
    SpriteRenderer sr;
    AudioSource audioSource;

    public void Pickup(GameObject player)
    {
        PlayerController pc = player.GetComponent<PlayerController>();
        pc.isBig = false;
        pc.isFire = true;
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
