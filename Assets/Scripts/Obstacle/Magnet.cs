using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    // Start is called before the first frame update
    public float MagnetPower=0.008f;
    private void OnTriggerStay(Collider other)
    {
        // Magnet bu taglara ait obje görünce çekmeye başlar
        if (other.tag.Equals("mainCharacter") || other.tag.Equals("opponent"))
        {
           
        var currentPosition = other.transform.position;
        other.transform.position = Vector3.Lerp(currentPosition, gameObject.transform.position, MagnetPower);
           
        }

    }
    
    // Update is called once per frame
    
}
