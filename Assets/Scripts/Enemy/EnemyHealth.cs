﻿using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;           
    public int currentHealth;                     
    public int scoreValue = 10;                           

    Animator anim;                             
    CapsuleCollider capsuleCollider;            
    bool isDead;                 
    Objectives objects;                             

    void Awake()
    {
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
    }

    void Update()
    {
    }

    public void TakeDamage( int amount, Vector3 hitPoint )
    {
        if( isDead )
            return;

        currentHealth -= amount;

        if( currentHealth <= 0 )
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger( "Dead" );
        Destroy( gameObject, 2f );
        objects.currentEnemiesKilled++;
    }
}