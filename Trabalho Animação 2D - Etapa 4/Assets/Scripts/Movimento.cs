using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Movimento : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D rb;

    [SerializeField] private int velocidade = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
        {
         horizontalInput = Input.GetAxis("Horizontal");
        }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * velocidade, rb.linearVelocity.y);
    }
}
