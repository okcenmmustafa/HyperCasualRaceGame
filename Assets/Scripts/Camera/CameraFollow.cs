using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smootSpeed = 0.150f;
    public Vector3 offset;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        // Kameranın Main Characteri takip etmesi
        transform.position = target.position + offset;
    }
}
