using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int lives;

    [HideInInspector]
    public bool facingRight = true;
    //jumping
    #region
    [HideInInspector]
    public bool doubleJump = false;

    public bool doubleJumpEnabled = false;
    #endregion

    //projectile
    #region
    [HideInInspector]
    public bool fireBallEnabled = false;
    public GameObject fireBall;
    public string fireButton = "Fire1";
    public float fireForce = 100f;
    public Transform firePoint;
    #endregion

    public float moveSpeed;
    public float maxSpeed = 5f;
    public float jumpSpeed;
    public float doubleJumpSpeed;
    public Transform groundCheck;


    private bool grounded = false;
    private Rigidbody2D rb2d;
    private Vector2 moveForce;
    private Vector2 jumpForce;
    private Vector2 doubleJumpForce;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpForce = new Vector2( 0, jumpSpeed );
        doubleJumpForce = new Vector2(0, doubleJumpSpeed);
        moveForce = new Vector2( moveSpeed, 0 );  
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
                        rb2d.AddForce(doubleJumpForce);
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
                GameObject b = GameObject.Instantiate(fireBall, firePosition, firePoint.rotation) as GameObject;

                if (b != null)
                {
                    Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
                    Vector2 force = firePoint.forward * fireForce;
                    rb.AddForce(force);
                }
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
        {
            grounded = true;
        }

        if (col.gameObject.CompareTag("PickUp"))
        {
            Destroy(col.gameObject);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}


