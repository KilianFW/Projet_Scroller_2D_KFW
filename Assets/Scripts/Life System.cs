using System;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public int currentLife;
    public int maxLife;
    public Transform respawnPoint;
    public GameObject RestartButton;
    public GameObject checkPoint;
    
    private Animator animator;

    private void Awake()
    {
        currentLife = maxLife;
        RestartButton.SetActive(false); 
    }

    public void TakeDamage()
    {
        currentLife -= 1;
        if (currentLife <= 0)
        {
            gameObject.SetActive(false);
            RestartButton.SetActive(true);
        }
    }

    public void Reset()
    {
        Debug.Log("Reset");
        RestartButton.SetActive(false);
        gameObject.SetActive(true);
        currentLife = maxLife;
        transform.position = respawnPoint.position;
    }

    public void UpdateCheckpoint(GameObject respawn)
    {
        respawnPoint = respawn.transform;
    }
}
