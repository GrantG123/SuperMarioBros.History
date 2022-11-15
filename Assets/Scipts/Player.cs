
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField]private float speed;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
    }
}
