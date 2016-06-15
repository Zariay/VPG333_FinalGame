using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int lives = 3;

    public bool facingRight;
    public bool keyPickedUp;
    public bool isDead = false;
    //jumping
    #region
    public bool doubleJump = false;

    public bool doubleJumpEnabled = false;
    #endregion

    //projectile
    #region
    public bool fireBallEnabled = false;
    public GameObject fireBall;
    public string fireButton = "Fire1";
    public float fireForce = 100f;
    public Transform firePoint;
    #endregion

    public float moveSpeed;
    public float maxSpeed = 5f;
    public float jumpSpeed = 37;
    public float knockBackSpeed;
    public Transform groundCheck;


    private bool grounded = false;
    private Rigidbody2D rb2d;
    private Vector2 knockBackForce;

    Objectives objectives;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        knockBackForce = new Vector2(knockBackSpeed, 0);
        objectives = FindObjectOfType<Objectives>();
        isDead = false;
    }

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        //Moving
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            facingRight = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            facingRight = true;
        }
        else
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);

        if (rb2d.velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else if (rb2d.velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);

        //Jumping
        #region
        if (doubleJumpEnabled == false)
        {
            if (Input.GetButtonDown("Jump") && grounded)
            {
                Jump();
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                if(grounded == true)
                {
                    Jump();
                    doubleJump = true;
                }
                else
                {
                    if (doubleJump == true)
                    {
                        Jump();
                        doubleJump = false;
                    }
                }
            }
        }
        #endregion

        if (fireBallEnabled == true)
        {
            if (Input.GetButtonDown(fireButton))
            {
                Vector2 firePosition = firePoint.position;
                Instantiate(fireBall, firePosition, firePoint.rotation);
            }
        }
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
    }

    void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
    }

    void OnCollisionEnter2D( Collision2D other )
    {
        if(other.gameObject.CompareTag( "ground" ) )
            grounded = true;

        if(other.gameObject.CompareTag("GroundEnemy"))
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(knockBackForce);

        if(other.gameObject.CompareTag("Bounce"))
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>(), true);

        if (other.gameObject.CompareTag("DoubleJump"))
        {
            doubleJumpEnabled = true;
            other.gameObject.SetActive(false);
        }
           
        if (other.gameObject.CompareTag("FireBall"))
        {
            fireBallEnabled = true;
            other.gameObject.SetActive(false);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
            objectives.score += 5;
        }

        if(other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            objectives.currentCollectables++;
        }

        if(other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            keyPickedUp = true;
        }

        if(other.gameObject.CompareTag("EndFlag") && keyPickedUp == true)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (other.gameObject.CompareTag("DeathZone"))
        {
            Destroy(this.gameObject);
            isDead = true;
        }
            
    }

}


