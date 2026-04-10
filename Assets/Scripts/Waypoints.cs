using System;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public EnemyBehavior reOrientation;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            reOrientation.direction *= -1;
        }
    }

    private void Start()
    {
        
    }
}
