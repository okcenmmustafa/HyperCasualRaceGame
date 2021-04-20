using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject paintSection;
    public GameObject raceSection;

     void Start()
    {
        raceSection.SetActive(true);
        paintSection.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<CharacterManager>().Finish();
        other.GetComponent<CharacterManager>().playerInfo.isFinish();
        if(other.tag.Equals("mainCharacter")){
            Camera.main.transform.rotation = Quaternion.Euler((float)-0.4, 0, 0);
            raceSection.SetActive(false);
            paintSection.SetActive(true);
        }
    }
}
