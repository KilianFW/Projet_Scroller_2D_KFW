using System;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public LifeSystem player;
    
    public float checkRadius;
    public float attackRadius;
    public float speed;
    public bool chasing;

    public bool isTooHigh;
    
    [Header("HeightCheck")] 
    [SerializeField] private float _castDistance;
    [SerializeField] private float _castRadius;
    [SerializeField] private Color _gizmosColor;
    
    [SerializeField] LayerMask groundLayer;
    
    private Rigidbody2D rb;
    private Transform target;
    private Vector2 movement;
    public Vector2 direction;
    private Animator animator;

    private bool isInChaseRange;
    private bool isAttackRange;

    [SerializeField] private float attackCooldown; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //movement = rb.linearVelocity;

        isTooHigh = HeightCheck();
        
        if (Vector2.Distance(transform.position, target.position) <= checkRadius)
        {
            //if ()
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

        if (attackCooldown > 0f)
        {
            attackCooldown -= Time.deltaTime;
        }
        
        if (Vector2.Distance(transform.position, target.position) <= attackRadius && attackCooldown <= 0f)
        {
            isAttackRange = true;
            Attack();
            attackCooldown = 1.5f;
        }
        else
        {
            isAttackRange = false;
        }
    }

    private bool HeightCheck()
    {
        return Physics2D.CircleCast(transform.position, _castRadius, Vector2.down, _castDistance, groundLayer);
    } 

    public void Attack()
    {
        player.TakeDamage();
    }
    
    public void OnDrawGizmos()
    {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(transform.position +(Vector3.down*_castDistance), _castRadius);
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
