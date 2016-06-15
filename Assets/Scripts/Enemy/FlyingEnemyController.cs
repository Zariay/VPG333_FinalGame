using UnityEngine;
using System.Collections;

public class FlyingEnemyController : MonoBehaviour
{
    PlayerController player;
    public float moveSpeed;
    public float playerRange;
    public bool playerInRange;
    public LayerMask playerLayer;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
        if (playerInRange)
            transform.Translate(Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            other.gameObject.GetComponent<PlayerController>().lives--;
        } 
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, playerRange);
    }
}
