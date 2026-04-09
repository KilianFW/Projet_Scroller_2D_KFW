using System;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemies")
        {
        }
    }
}
