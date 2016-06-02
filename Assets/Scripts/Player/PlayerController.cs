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
    public bool jump = false;
    [HideInInspector]
    public bool doubleJump = false;
    [HideInInspector]
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

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;


    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        while (doubleJumpEnabled == false)
        {
            if (Input.GetButtonDown("Jump") && grounded)
            {
                jump = true;
            }
            if (doubleJumpEnabled == true)
                break;
        }
        
        while(doubleJumpEnabled == true)
        {
            if (Input.GetButtonDown("Jump") && grounded)
            {
                jump = true;
            }
            else if(doubleJump == false)
            {
                doubleJump = true;
            }
        }

        if(fireBallEnabled)
        {
            if (Input.GetButtonDown(fireButton))
            {
                Vector3 firePosition = firePoint.position;
                GameObject b = GameObject.Instantiate(fireBall, firePosition, firePoint.rotation) as GameObject;

                if (b != null)
                {
                    Rigidbody rb = b.GetComponent<Rigidbody>();
                    Vector3 force = firePoint.forward * fireForce;
                    rb.AddForce(force);
                }
            }
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        //    if (h > 0 && !facingRight)
        //      Flip ();
        //else if (h < 0 && facingRight)
        //  Flip ();

        if (jump)
        {
            //anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
        else if(doubleJump)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce / 2));
            doubleJump = false;
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


