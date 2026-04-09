using System;
using System.Collections;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float timer;
    public float falltimer;
    public float respawntimer;
    public bool platformVisible = true;
    public bool firstContact = false;
    
    [SerializeField] LayerMask groundLayer;

    private void Start()
    {
        firstContact = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (firstContact == false)
        {
            Debug.Log(other.gameObject.name);
            timer = falltimer;
            firstContact = true;
        }

        /*/*if (timer < 0f)
        {
            Debug.Log("Falling Platform");
            gameObject.SetActive(false);
        }#1#
    }
    if (gameObject.activeSelf == false)
    {
        timer = respawntimer;
        /*if (timer < 0f)
        {
            gameObject.SetActive(true);
        }#1#*/

    }

    /*public void PlatformToggle()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            timer = respawntimer;
        }
        else gameObject.SetActive(true);
    }*/

    public void PlatformToggle()
    {
        if (platformVisible)
        {
            gameObject.SetActive(false);
            platformVisible = false;
            timer = respawntimer;
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
    

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                if (platformVisible == true)
                {
                    PlatformToggle();
                }
            }
        }
    }
}
