using UnityEngine;
using System.Collections;

public class PlayerAttackFromBottom : MonoBehaviour
{
    int damage;

    public float bounceOnEnemy;

    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = transform.parent.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("GroundEnemy"))
        {
            other.GetComponent<EnemyHealth>().SendMessage("Take Damage", damage);
            rb2d.velocity = new Vector2(rb2d.velocity.x, bounceOnEnemy);
        }
    }
}
