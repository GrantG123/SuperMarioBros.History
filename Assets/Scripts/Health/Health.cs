using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public static float currentHealth { get; private set; }
    private bool dead;

    [Header ("iframes")]
    [SerializeField] private float invincibleDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteColor;



    private void Awake()
    {
        currentHealth = startingHealth;
        spriteColor = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        currentHealth -= damage;

        if(currentHealth > 0)
        {
            StartCoroutine(Invincible());
        }
        else
        {   
            if (!dead)
            {
                GetComponent<Player>().enabled = false;
                dead = true;
            }
            
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invincible()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteColor.color = new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(invincibleDuration / (numberOfFlashes * 2));
            spriteColor.color = Color.white;
            yield return new WaitForSeconds(invincibleDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }
}
