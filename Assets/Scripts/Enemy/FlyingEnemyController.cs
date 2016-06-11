using UnityEngine;
using System.Collections;

public class FlyingEnemyController : MonoBehaviour
{
    PlayerHealth playerHealth;
    PlayerController player;
    EnemyHealth enemyHealth;
    public float moveSpeed;
    public float playerRange;
    public bool playerInRange;
    public LayerMask playerLayer;

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
        if (playerInRange)
            transform.Translate(Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime));
    }
}
