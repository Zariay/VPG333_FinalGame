using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;
    public Transform groundCheck;
     public bool jump = false;
       public float maxSpeed = 5f;

    private Vector2 moveForce;

    private Vector2 jumpForce;
    private Rigidbody2D rb2d;
    private bool grounded = false;
   

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        jumpForce = new Vector2(0,jumpSpeed);
        moveForce = new Vector2(moveSpeed, 0);      
	}


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }



    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButton("Jump") && grounded)
        {
            jump = true;
        }
    }
  


        
	
    void FixedUpdate()
    {
       

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb2d.AddForce(jumpForce);
        }

        float h = Input.GetAxis("Horizontal");

        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(h*moveForce, ForceMode2D.Impulse);
        }
          
        if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y); 
        
        }
        else if (h == 0)
        {
            if (rb2d.velocity.x <= maxSpeed)
            {
                rb2d.velocity =  new Vector2(0,rb2d.velocity.y);
            }
            if (rb2d.velocity.x >= maxSpeed)
            {
                rb2d.velocity = Vector2.zero;
            }

        }


        if (jump == true && grounded == true)
        {
            rb2d.AddForce(jumpForce);
            jump = false;
        }
    }
}
