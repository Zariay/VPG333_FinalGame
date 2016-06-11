using UnityEngine;
using System.Collections;

public class GroundEnemyController : MonoBehaviour
{
    PlayerController player;               
    PlayerHealth playerHealth;      
    EnemyHealth enemyHealth;
    public float moveSpeed;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
            transform.Translate(new Vector3(moveSpeed / 2, 0, 0) * Time.deltaTime);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bounce"))
            moveSpeed *= -1;
    }
}