using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     
    public int attackDamage = 10;               
    PlayerController player;                          
    PlayerHealth playerHealth;                  
    EnemyHealth enemyHealth;                   
    bool playerInRange;                         
    float timer;                                

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }
    }

    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
            player.knockbackCount = player.knockbackLength;

            if (player.transform.position.x < transform.position.x)
                player.knockFromRight = true;
            else
                player.knockFromRight = false;
        }
    }
}