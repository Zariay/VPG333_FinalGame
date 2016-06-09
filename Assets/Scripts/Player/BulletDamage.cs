using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour
{
    public int damage = 2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            Destroy(transform.gameObject);
            other.gameObject.SendMessage("TakeDamage", damage);
        }
    }
}
