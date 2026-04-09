using System;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public LifeSystem player;
    
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Contact");
        player.TakeDamage();
    }
}
