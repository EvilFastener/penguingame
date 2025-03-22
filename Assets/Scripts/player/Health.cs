using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] public float maxHealth;
    public float currentHealth;
    private Animator anim;
    private bool dead;
    public Text gameOvertext;

    public HealthBar healthBar;

    /*[Header("components")]
    [SerializeField]
    private Behaviour[] components;
    private bool invulnerable;*/

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;
    void Awake()
    {
        currentHealth = maxHealth;
       // healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        if (damage >= currentHealth)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        }
        print(currentHealth);
        //currentHealth -= damage;
        if (currentHealth > 0)
        {
            StartCoroutine(Invunerability());
            SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if(dead==false)
            {
                StartCoroutine(Invunerability());
                anim.SetTrigger("die");

                
                //if(GetComponent<mosv2>() != null) 
                   // GetComponent<mosv2>().enabled = false;

               /* if(GetComponentInParent<Patrol>() != null)
                    GetComponentInParent<Patrol>().enabled = false;

                if(GetComponent<Knight>() != null)
                    GetComponent<Knight>().enabled = false;*/

                dead = true;
                SoundManager.instance.PlaySound(deathSound);
            };
        }
        healthBar.SetHealth(currentHealth);
    }
    
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(8,7, true);
        for (int i = 0; i < 1; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(1);
            //yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes *2 ));
            spriteRenderer.color = Color.white;
            //yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 7, false);
    }
    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
    }
    public void Rrespawn()
    {
        dead = false;
        AddHealth(maxHealth);
        anim.ResetTrigger("die");
        anim.Play("idle");
        StartCoroutine(Invunerability());
        //GetComponent<mosv2>().enabled = true;
        healthBar.SetHealth(currentHealth);
    }
}

