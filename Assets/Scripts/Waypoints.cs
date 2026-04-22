using System;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public EnemyBehavior reOrientation;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            reOrientation = other.GetComponent<EnemyBehavior>();
            reOrientation.direction *= -1;
        }
    }
}