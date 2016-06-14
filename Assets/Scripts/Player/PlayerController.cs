using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int lives = 3;

    public bool facingRight;
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
    public float jumpSpeed;
    public float knockBackSpeed;
    public Transform groundCheck;


    private bool grounded = false;
    private Rigidbody2D rb2d;
    private Vector2 knockBackForce;

    //player knockback
    #region
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    #endregion

    Objectives objectives;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        knockBackForce = new Vector2(knockBackSpeed, 0);
        objectives = FindObjectOfType<Objectives>();
    }

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        //Moving
        if(Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            facingRight = false;
        }

        if(Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            facingRight = true;
        }
           
        if (Input.GetKey(KeyCode.S))
            rb2d.velocity = new Vector2(0f, 0f);

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
        
        if(knockbackCount <= 0)
        {
            
        }
        else
        {
            if(knockFromRight)
                rb2d.velocity = new Vector2(-knockback, 1f);

            if (!knockFromRight)
                rb2d.velocity = new Vector2(knockback, 1f);
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
       
    }

    void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
    }

    void OnCollisionEnter2D( Collision2D col )
    {
        if( col.gameObject.CompareTag( "ground" ) )
            grounded = true;

        if (col.gameObject.CompareTag("PickUp"))
            Destroy(col.gameObject);

        if(col.gameObject.CompareTag("GroundEnemy"))
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(knockBackForce);

        if(col.gameObject.CompareTag("Bounce"))
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>(), true);

        if (col.gameObject.CompareTag("DoubleJump"))
            doubleJumpEnabled = true;

        if (col.gameObject.CompareTag("FireBall"))
            fireBallEnabled = true;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}


