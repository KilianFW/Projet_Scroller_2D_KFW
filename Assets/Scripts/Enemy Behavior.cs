using System;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public LifeSystem player;
    
    public float checkRadius;
    public float attackRange;
    public float speed;
    public bool chasing;

    public bool isNotTooHigh;
    
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

    public bool isInChaseRange;
    public bool isAttackRange;
    public LayerMask mask;
    public float castLength;
    public RaycastHit2D hit;

    public bool stop;

    [SerializeField] private float attackCooldown; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        hit = Physics2D.Raycast(transform.position, direction, attackRange, mask);

        
    }

    private void Update()
    {
        //movement = rb.linearVelocity;

        isNotTooHigh = HeightCheck();
        Debug.DrawRay(transform.position, direction * attackRange, Color.red);
        
        if (Vector2.Distance(transform.position, target.position) <= checkRadius)
        {
            if (stop == false)
            {
                isInChaseRange = true;
            
                speed = 6;
                //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                Vector2 directionToTarget = (target.position - transform.position).normalized;
                directionToTarget.y = 0;
                rb.linearVelocity =  speed * directionToTarget;
            }
        }
        else 
        {
            isInChaseRange = false;
            speed = 5;
            rb.linearVelocity = new Vector2(speed * direction.x, 0);
        }

        if (attackCooldown > 0f)
        {
            attackCooldown -= Time.deltaTime;
        }

        if (hit == true)
        {
            ColliderRaycast();
        }
    }

    public void ColliderRaycast()
    {
        if (hit.collider.CompareTag("Player") && attackCooldown <= 0)
        {
            isAttackRange = true;
            Attack();
            attackCooldown = 1.75f;
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
        Gizmos.DrawWireSphere(transform.position +((new Vector3((0.8f * direction.x), -1.5f, 0f))*_castDistance), _castRadius);
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
