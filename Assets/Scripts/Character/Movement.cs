using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
     CharacterManager characterManager;
    public float rotSpeed = 5;
    public float speed = 5;
  
    private void Start()
    {
        characterManager = GetComponent<CharacterManager>();

    }
    public void Move(Quaternion PlayerRot,Vector3 TargetPosition)
    {

        if (transform.position == TargetPosition )
        {
            characterManager.characterController.IsMoving = false;
            characterManager.characterAnimation.Wait();

        }
        else if (Vector3.Distance(transform.position, TargetPosition) > 5)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, PlayerRot, rotSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, speed * Time.deltaTime);
            speed = 8;
            rotSpeed = 8;
            characterManager.characterAnimation.Run();

        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, PlayerRot, rotSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, speed * Time.deltaTime);
            speed = 5;
            characterManager.characterAnimation.Walk();
        }
       

    }
}
