using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Knight : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;

    [Header("Player Layer")]
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownaTimer = Mathf.Infinity;

    [Header("Attack Sound")]
    [SerializeField] private AudioClip attackSound;

    private Animator animator;
    private Health playerHealth;

    private Patrol patrol;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        patrol = GetComponentInParent<Patrol>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownaTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if(cooldownaTimer >= attackCooldown)
            {
                cooldownaTimer = 0;
                animator.SetTrigger("attack");
                SoundManager.instance.PlaySound(attackSound);
            }
        }

        if (patrol != null)
            patrol.enabled = !PlayerInSight();
            
        
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0,Vector2.left, 0, playerLayer);
        
        if(hit.collider != null)
            playerHealth = hit.collider.GetComponent<Health>();

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
                new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
