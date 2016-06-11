using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int lives = 3;

    [HideInInspector]
    public bool facingRight = true;
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
    private Vector2 moveForce;
    private Vector2 jumpForce;
    private Vector2 knockBackForce;

    Objectives objectives;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpForce = new Vector2( 0, jumpSpeed );
        moveForce = new Vector2( moveSpeed, 0 );
        knockBackForce = new Vector2(knockBackSpeed, 0);
        objectives = GameObject.FindObjectOfType<Objectives>();
    }

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        //Jumping
        if (doubleJumpEnabled == false)
        {
            if (Input.GetButtonDown("Jump") && grounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(jumpForce);
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                if(grounded == true)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(jumpForce);
                    doubleJump = true;
                }
                else
                {
                    if (doubleJump == true)
                    { 
                        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                        rb2d.AddForce(jumpForce);
                        doubleJump = false;
                    }
                }
            }
        }

        if(fireBallEnabled == true)
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
        float h = Input.GetAxis("Horizontal");

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(h*moveForce, ForceMode2D.Impulse);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        else if (h == 0)
        {
            if (rb2d.velocity.x <= maxSpeed)
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
            if (rb2d.velocity.x >= maxSpeed)
            {
                rb2d.velocity = Vector2.zero;
            }
        }
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


