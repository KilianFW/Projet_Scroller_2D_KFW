using System;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float checkRadius;
    public float attackRadius;
    public float speed;
    public int orientation;
    public bool chasing;
    
    private Rigidbody2D rb;
    private Transform target;
    private Vector2 movement;
    public Vector2 direction;
    private Animator animator;

    private bool isInChaseRange;
    private bool isAttackRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        movement = rb.linearVelocity;
        Vector2 dir = movement;
    }
}
