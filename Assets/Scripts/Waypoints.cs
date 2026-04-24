using System;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public EnemyBehavior reOrientation;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (other.GetComponent<EnemyBehavior>().isInChaseRange == false)
            {
                reOrientation = other.GetComponent<EnemyBehavior>();
                reOrientation.direction *= -1;
            }

            if (other.GetComponent<EnemyBehavior>().isInChaseRange == true)
            {
                if (other.GetComponent<EnemyBehavior>().isNotTooHigh == false)
                {
                    other.GetComponent<EnemyBehavior>().stop = true;
                }
                else
                {
                    other.GetComponent<EnemyBehavior>().stop = false;
                }
            }
        }
    }
}