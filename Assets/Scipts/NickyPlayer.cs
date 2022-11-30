using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickyPlayer : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    [SerializeField] private float speed;
    private BoxCollider2D boxCollider;
    public Animator animator;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void Update()
    {
        //basic movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //run animation
        animator.SetFloat("Aspeed", Mathf.Abs(horizontalInput));

        //flips mario when he changes direction
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 4);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-4, 4, 4);

        if (Input.GetKey(KeyCode.Space) && isGrounded())
            Jump();
          //animation fofr jumping
        if (Input.GetKey(KeyCode.Space))
            animator.SetBool("Aisjumping", true);
        if (isGrounded())
            animator.SetBool("Aisjumping", false);
        //animation for crouching
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Aiscrouching", true);
        }
        else
            animator.SetBool("Aiscrouching", false);


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
