using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<CharacterManager>().Die();
        other.transform.position = spawnPoint.transform.position;
    }
}
