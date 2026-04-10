using System;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public LifeSystem player;
    
    public float checkRadius;
    public float attackRadius;
    public float speed;
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
        //movement = rb.linearVelocity;
        
        if (Vector2.Distance(transform.position, target.position) <= checkRadius)
        {
            speed = 6;
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Vector2 directionToTarget = (target.position - transform.position).normalized;
            directionToTarget.y = 0;
            rb.linearVelocity =  speed * directionToTarget;
        }
        else
        {
            speed = 5;
            rb.linearVelocity = new Vector2(speed * direction.x, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector2 directionToTarget =  (target.position - transform.position).normalized; 
            player.TakeDamage();
            rb.linearVelocity = -directionToTarget;
        }
    }
}
