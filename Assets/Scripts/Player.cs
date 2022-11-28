
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;

    private Rigidbody2D body;
    [SerializeField]private float speed;
    [SerializeField]private float jumpPower;
    private BoxCollider2D  boxCollider;
    private float wallJumpCooldown;
    //private Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //basic movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //run animation
        animator.SetFloat("Aspeed", Mathf.Abs(speed));

        //flips mario when he changes direction
        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 4);
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-4, 4, 4);

<<<<<<< HEAD
        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);

      

=======
        if (Input.GetKey(KeyCode.Space) && isGrounded())
            Jump();

<<<<<<< HEAD:Assets/Scripts/Player.cs
        //anim.SetBool("run", horizontalInput != 0); 
        //anim.SetBool("grounded", isGrounded());

        //wall jump controlls mah fahkaaaaa
        if (wallJumpCooldown > 0.2f){

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
            
            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 7;    

             if (Input.GetKey(KeyCode.Space))
            Jump(); 
    }
    else
        wallJumpCooldown = Time.deltaTime;
=======
        anim.SetBool("run", horizontalInput != 0);
>>>>>>> ca17f632e1728cbe3554095929c3cc026f5450b1
>>>>>>> d64a8da5b43f25fcced08e0be3ff1b3fe0970e17:Assets/Scipts/Player.cs
    }

    //derpy meme face
    private void Jump()
    {
        if(isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }
        else if (onWall() && !isGrounded())
        {
            wallJumpCooldown = 0;
            body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

        private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }  
}
