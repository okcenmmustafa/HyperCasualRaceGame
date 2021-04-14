using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Quaternion playerRot;
    Animator anim;
    public float rotSpeed = 5;
    public float speed = 5;
    public bool isMoving = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
        else
        {
            isMoving = false;
            anim.SetInteger("movementMode", 0);

        }
        if (isMoving)
        {
            Move();

        }


    }
    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,1000))
        {
            targetPosition = hit.point;

            if (hit.transform.tag == "mainCharacter" && hit.transform.tag=="obstacle")
            {
                isMoving = false;
                anim.SetInteger("movementMode", 0);

            }
            else { 
                lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y, targetPosition.z - transform.position.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);
            isMoving = true;
                anim.SetInteger("movementMode", 1);
            }
        }
    }
    void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,playerRot,rotSpeed*Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) > 5)
        {
            speed = 8;
            rotSpeed = 8;
            anim.SetInteger("movementMode", 2);

        }
        else
        {
            speed = 5;
            anim.SetInteger("movementMode", 1);
        }
        if (transform.position == targetPosition )
        {
            isMoving = false;
            anim.SetInteger("movementMode", 0);

        }
        
    }
}
