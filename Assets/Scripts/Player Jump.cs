using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jump;
    private bool isGrounded;
    
    [SerializeField] LayerMask groundLayer;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = GroundedCheck();
        //Debug.Log(isGrounded);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jump), ForceMode2D.Impulse);
        }
    }

    public bool GroundedCheck()
    {
        return Physics2D.CircleCast(transform.position, .5f, Vector2.down, .525f, groundLayer);
    }
}
