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
    public bool isDead;

    public HeroKnight anim;

    public float iFrames;
    
    private Animator animator;

    private void Awake()
    {
        currentLife = maxLife;
        isDead = false;
        RestartButton.SetActive(false); 
    }

    public void TakeDamage()
    {
        if (iFrames <= 0f && !isDead)
        {
            anim.m_animator.SetTrigger("Hurt");
            currentLife -= 1;
            iFrames = 1f;
            if (currentLife <= 0)
            {
                anim.m_animator.SetTrigger("Death");
                gameObject.GetComponent<HeroKnight>().enabled = false;
                isDead = true;
                //gameObject.SetActive(false);
                RestartButton.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (iFrames > 0f)
        {
            iFrames -= Time.deltaTime;
        }
    }

    public void Reset()
    {
        Debug.Log("Reset");
        RestartButton.SetActive(false);
        gameObject.SetActive(true);
        gameObject.GetComponent<HeroKnight>().enabled = true;
        anim.m_animator.SetTrigger("Idle");
        currentLife = maxLife;
        isDead = false;
        transform.position = respawnPoint.position;
    }

    public void UpdateCheckpoint(GameObject respawn)
    {
        respawnPoint = respawn.transform;
    }
}
