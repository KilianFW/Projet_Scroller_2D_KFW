using System;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jump;
    private bool isGrounded;
    
    private Animator animator;

    [Header("GroundCheck")] 
    [SerializeField] private float _castDistance;
    [SerializeField] private float _castRadius;
    [SerializeField] private Color _gizmosColor;
    
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
        return Physics2D.CircleCast(transform.position, _castRadius, Vector2.down, _castDistance, groundLayer);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(transform.position +(Vector3.down*_castDistance), _castRadius);
    }
}
