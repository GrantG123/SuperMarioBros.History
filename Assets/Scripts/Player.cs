
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    [SerializeField]private float speed;
    [SerializeField]private float jumpPower;
    private BoxCollider2D  boxCollider;
    public Animator animator;
    private float wallJumpCooldown;
    private float horizontalInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //basic movement
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //run animation
        animator.SetFloat("Aspeed", Mathf.Abs(horizontalInput));

        //flips mario when he changes direction
        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 4);
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-4, 4, 4);

        if (Input.GetKey(KeyCode.Space) && isGrounded())
            Jump();

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

    public bool canAttack()
    {
        return horizontalInput == 0 && !onWall();
    }
}
