using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DeathCollide : MonoBehaviour
{
    private bool isDead = false;
    void Update()
    {
        if( Input.GetButtonDown( "Reset" ) )
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
        }
    }
    void OnTriggerEnter2D( Collider2D other )
    {
        if( other.name == "Player" )
        {
            Debug.Log( "Me" );
            Destroy( other.gameObject );
            isDead = true;
        }
    }

}
