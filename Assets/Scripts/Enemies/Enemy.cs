using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public abstract class Enemy : MonoBehaviour
{
    protected SpriteRenderer sr;
    protected Animator anim;
    protected int health;
    [SerializeField] protected int maxHealth;

    public virtual void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (maxHealth <= 0) maxHealth = 1;

        health = maxHealth;
    }

    public virtual void TakeDamage(int damageValue)
    {
        health -= damageValue;

        if (health <= 0)
        {
            anim.SetTrigger("Death");
            if (transform.parent != null) Destroy(transform.parent.gameObject, 1);
            else Destroy(gameObject, 2);
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
