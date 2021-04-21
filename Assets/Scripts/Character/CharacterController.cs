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

    void Update()
    {
        // Play butona basılmamışsa veya karakter bitiş noktasında değilse swerve mechanics çalışır 
        if (!characterManager.isFinishedTheRace && characterManager.isPressedPlay)
        {
         
         if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
        else
        {
            isMoving = false;
            characterManager.characterAnimation.Wait();
                characterManager.RunnigSound.Play();

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
        //Unity Physics kullanılarak karakterin tıklanılan bölgeye yönlenmesi sağlanmıştır.

        if(Physics.Raycast(ray,out hit,1000))
        {
            targetPosition = hit.point;

            //Main Character kendisine tıklayınca oluşan bir bug çözümü
            if (hit.transform.tag.Equals("mainCharacter") )
            {
                isMoving = false;
                characterManager.characterAnimation.Wait();

            }
            else { 
                // Main Character hareketi 
                lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y, targetPosition.z - transform.position.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);
            isMoving = true;
            characterManager.characterAnimation.Walk();


            }
        }
    }
    
}
