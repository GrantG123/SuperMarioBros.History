
using UnityEngine;

public class Player : MonoBehaviour
{
<<<<<<< HEAD
    public Animator animator;

=======
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private LayerMask wallLayer;
>>>>>>> ca17f632e1728cbe3554095929c3cc026f5450b1
    private Rigidbody2D body;
    [SerializeField]private float speed;
    private BoxCollider2D  boxCollider;
    private Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

        anim.SetBool("run", horizontalInput != 0);
>>>>>>> ca17f632e1728cbe3554095929c3cc026f5450b1
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
     
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
