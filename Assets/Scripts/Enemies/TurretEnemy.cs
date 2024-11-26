using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Enemy
{
    [SerializeField] private float projectileFireRate = 2;
    private float timeSinceLastFire = 0;
    [SerializeField] private float range = 5;
    

    public override void Start()
    {
        base.Start();
        if (projectileFireRate <= 0)
            projectileFireRate = 2;

        if (range <= 0)
            range = 5;
    }

    private void Update()
    {
        Transform player = GameManager.Instance.PlayerInstance.transform;

        if (!player) return;
        AnimatorClipInfo[] curPlayingClips = anim.GetCurrentAnimatorClipInfo(0);

        if (curPlayingClips[0].clip.name.Contains("Idle"))
        {
            if((transform.position.x - player.position.x <= range) && (transform.position.x - player.position.x >= -range))
            {
                if (Time.time >= timeSinceLastFire + projectileFireRate)
                {
                    anim.SetTrigger("Fire");
                    timeSinceLastFire = Time.time;
                }
                Turn(player);
            }
        }
    }

    public override void TakeDamage(int damageValue)
    {
        base.TakeDamage(damageValue);
    }

    private void Turn(Transform player)
    {
        if (transform.position.x < player.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
