using System;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public LifeSystem player;
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Contact");
            player.TakeDamage();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("StayContact");
            other.gameObject.GetComponent<LifeSystem>().TakeDamage();
        }
    }
}
