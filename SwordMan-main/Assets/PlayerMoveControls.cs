using UnityEngine;

[RequireComponent(typeof(GatherInput), typeof(Rigidbody2D))]
public class PlayerMoveControls : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    private GatherInput input;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private Animator animator;

    private void Start()
    {
        input = GetComponent<GatherInput>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(input.moveInput.x * speed, rb.linearVelocity.y);

        if (input.moveInput.x > 0.1f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (input.moveInput.x < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (input.jumpPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            input.ResetJump();
        }

        animator.SetBool("isJumping", !isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    private void Update()
    {
        float moveSpeed = Mathf.Abs(input.moveInput.x);
        animator.SetFloat("Speed", moveSpeed);
    }
}
