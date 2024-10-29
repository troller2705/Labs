using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    SpriteRenderer sr;

    public Vector2 initialShotVelocity;

    public Transform spawnR;
    public Transform spawnL;

    public Projectile ProjectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (initialShotVelocity == Vector2.zero)
        {
            Debug.Log("Initial shot velocity is zero giving it a default value");
            initialShotVelocity.x = 7.0f;
        }
        if (!spawnL || !spawnR || !ProjectilePrefab)
        { 
            Debug.Log($"Please set default values on the shoot script for {gameObject.name}");
        }
    }

    public void Fire()
    {
        if (!sr.flipX)
        {
            Projectile curProjectile = Instantiate(ProjectilePrefab, spawnR.position, spawnR.rotation);
            curProjectile.SetVelocity(initialShotVelocity);
        }
        else
        {
            Projectile curProjectile = Instantiate(ProjectilePrefab, spawnL.position, spawnL.rotation);
            curProjectile.SetVelocity(-initialShotVelocity);
        }
    }
}
