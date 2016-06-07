using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            
    public int currentHealth;                                   
    public Slider healthSlider;                                

    Animator anim;                                              
    bool isDead;                                           
    bool damaged;
    public PlayerController player;

    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        currentHealth = startingHealth;
    }

    void Update()
    {
       
    }


    public void TakeDamage( int amount )
    {
        currentHealth -= amount;

        healthSlider.value = currentHealth;

        if( currentHealth <= 0 && !isDead )
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        anim.SetTrigger( "Die" );
        player.enabled = false;
        player.fireBallEnabled = false;
    }
}