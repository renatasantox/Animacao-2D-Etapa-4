using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 7f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool andando;
    private bool noChao;

    public Transform verificadorChao;
    public LayerMask layerChao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimento horizontal
        float movimento = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(movimento * velocidade, rb.linearVelocity.y);

        // Flip do sprite
        if (movimento > 0)
            spriteRenderer.flipX = false;
        else if (movimento < 0)
            spriteRenderer.flipX = true;

        // Verifica se está no chão
        noChao = Physics2D.OverlapCircle(verificadorChao.position, 0.2f, layerChao);

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }

        // Animações
        andando = movimento != 0;
        animator.SetBool("Andando", andando);
        animator.SetBool("NoChao", noChao);
    }
}