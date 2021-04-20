using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    CharacterManager characterManager;
   private Vector3 targetPosition;
   private Vector3 lookAtTarget;
   private Quaternion playerRot;

    private bool isMoving = false;
    
    void Start()
    {
        characterManager = GetComponent<CharacterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!characterManager.isFinishedTheRace)
        {
         
         if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
        else
        {
            isMoving = false;
            characterManager.characterAnimation.Wait();

        }
        if (isMoving)
        {
           characterManager.Movement.Move(playerRot, targetPosition);

        }


        }
    }
    public bool IsMoving   
    {
        get { return isMoving; }   
        set { isMoving = value; }  
    }
    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,1000))
        {
            targetPosition = hit.point;

            if (hit.transform.tag == "mainCharacter" || hit.transform.tag=="obstacle")
            {
                isMoving = false;
                characterManager.characterAnimation.Wait();

            }
            else { 
                lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y, targetPosition.z - transform.position.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);
            isMoving = true;
            characterManager.characterAnimation.Walk();

            }
        }
    }
    
}
