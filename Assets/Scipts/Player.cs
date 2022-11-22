
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;

    private Rigidbody2D body;
    [SerializeField]private float speed;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
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

        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);

      

    }
}
