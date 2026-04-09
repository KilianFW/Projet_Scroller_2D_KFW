using System;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public LifeSystem player;
    private bool firstContact = false;
    
    private void OnTriggerEnter2D()
    {
        if (firstContact == false)
        {
            Debug.Log("Checkpoint Set");
            player.UpdateCheckpoint(gameObject);
            firstContact = true;
        }
    }
}
