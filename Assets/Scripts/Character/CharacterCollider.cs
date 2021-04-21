using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterManager characterManager;
    Vector3 spawnPointPosition;
    void Start()
    {
        characterManager = GetComponent<CharacterManager>();
        spawnPointPosition = characterManager.spawnPoint.transform.position;
    }
     void OnTriggerEnter(Collider other)
    {
        //Karakterlerin öldürücü bir engelle karşılaştığında verdiği yanıtlar
        if (other.tag.Equals("obstacle"))
        {

            if (gameObject.tag.Equals("mainCharacter"))
            {
                StartCoroutine(Dead(1));
            }
            else
            {
                DeadFunctionforOpponent();
            }
        }
    }
    private IEnumerator Dead( float waitTime)
    {
        characterManager.Die();
        transform.localScale = (gameObject.transform.localScale * 0.1f);

        //temastan sonra Partical effect 
        characterManager.DeadPartical.transform.position = gameObject.transform.position;
        characterManager.DeadPartical.Play();

        yield return new WaitForSeconds(waitTime);
       
        //belirli bir süre bekledikten sonra başlangıç noktasında yeniden doğma
        transform.localScale = (gameObject.transform.localScale * 10f);
        transform.position = new Vector3(spawnPointPosition.x + Random.Range(1, 20), spawnPointPosition.y, spawnPointPosition.z);


    }
    void  DeadFunctionforOpponent()
    {
        //AI rakipler için de böyle bir yapı yaptım çünkü Ienum ile navmesh problem oluşturuyordu.
        characterManager.Die();
        transform.localScale = (gameObject.transform.localScale * 0.1f);
        //temastan sonra Partical effect 
        characterManager.DeadPartical.transform.position = gameObject.transform.position;      
        characterManager.DeadPartical.Play();
        transform.localScale = (gameObject.transform.localScale * 10f);
        transform.position = new Vector3(spawnPointPosition.x + Random.Range(1, 20), spawnPointPosition.y, spawnPointPosition.z);



    }

}
