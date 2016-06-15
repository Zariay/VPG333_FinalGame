using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour
{
    public int damage = 2;
    LevelManager instance;

    PlayerController player;
    public float speed;
    new Rigidbody2D rigidbody2D;

    void Start()
    {
        instance = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<PlayerController>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (player.facingRight == false)
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
            Destroy(this.gameObject);
            instance.currentEnemiesKilled++;
        }

        /*if (other.CompareTag("Boss"))
        {
            other.GetComponent<EnemyHealth>().SendMessage("TakeDamage", damage);
        }*/
           
       if(other.CompareTag("BreakableBlock"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
