using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour
{
    public int damage = 2;
    Objectives objectives;

    PlayerController player;
    public float speed;
    new Rigidbody2D rigidbody2D;

    void Start()
    {
        objectives = GameObject.FindObjectOfType<Objectives>();
        player = GameObject.FindObjectOfType<PlayerController>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (player.transform.localScale.x < 0)
            speed = -speed;
    }

    void Update()
    {
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GroundEnemy") || other.CompareTag("FlyingEnemy"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Boss"))
        {
            other.SendMessage("TakeDamage", damage);
        }
           
        Destroy(gameObject);
    }
}
