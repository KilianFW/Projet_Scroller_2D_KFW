using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.linearVelocity.y);
    }
}
