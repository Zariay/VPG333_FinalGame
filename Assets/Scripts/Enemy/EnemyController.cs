using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    Transform player;               
    PlayerHealth playerHealth;      
    EnemyHealth enemyHealth;
    public float moveSpeed;
    public float playerRange;
    public bool playerInRange;
    public LayerMask playerLayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (this.gameObject.tag == "GroundEnemy")
        {
            transform.Translate(new Vector3(moveSpeed / 2, 0, 0) * Time.deltaTime);
        }
        else if (this.gameObject.tag == "FlyingEnemy")
        {
            playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
            if(playerInRange)
                transform.Translate(Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bounce"))
            moveSpeed *= -1;
    }
}