using System;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 offSet;
    public Vector3 moveMultiplier;
  


    private void Update()
    {

        transform.position = new Vector3(followTarget.position.x * moveMultiplier.x + offSet.x, followTarget.position.y * moveMultiplier.y + offSet.y, followTarget.position.z * moveMultiplier.z + offSet.z);
    }
}
