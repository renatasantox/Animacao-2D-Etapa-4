using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4f;

    private Rigidbody2D rb;
    private Animator animator;

    private float moveX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        animator.SetBool("Andando", false); 
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        if (moveX != 0)
            animator.SetBool("Andando", true);
        else
            animator.SetBool("Andando", false);

        if (moveX > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveX < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }
}
