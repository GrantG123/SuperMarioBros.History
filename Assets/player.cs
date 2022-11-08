/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    horizontal movement
    public float moveSpeed = 10f;
    public Vector2 direction;

    gravitycomponent
    public Rigidbody2D rigid;

    Physics
    public float maxSpeed = 7f;
    Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        moveCharacter(direction.x);
    }

    void moveCharacter(float horizontal)
    {
        rigid.AddForce(Vector2.right * horizontal * moveSpeed);

        animator.SetFloat("horizontal", Mathf.Abs(rigid.velocity.x));

        /* if((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
         {
             Flip();
         }
        if (Mathf.Abs(rigid.velocity.x) > maxSpeed)
        {
            rigid.velocity = new Vector2(Mathf.Sign(rigid.velocity.x) * maxSpeed, rigid.velocity.y);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quanternion.Euler(0, facingRight ? 0 : 180, 0);
    }
}
*/