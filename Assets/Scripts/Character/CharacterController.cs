using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Swerve swipeControls;
    private Vector3 desiredPosition=Vector3.zero;
    private Vector3 lookAtTarget;
    private Quaternion playerRot;
    private CharacterManager characterManager;
    private void Start()
    {
        characterManager = GetComponent<CharacterManager>();
    }
    void Update()
    {
        if (!characterManager.isFinishedTheRace && characterManager.isPressedPlay)
        {
            if (Mathf.Abs(swipeControls.SwipeDelta.x) > 0 || Mathf.Abs(swipeControls.SwipeDelta.y) > 0)
            {
                if (Mathf.Abs(swipeControls.SwipeDelta.x) < 1 || Mathf.Abs(swipeControls.SwipeDelta.y) < 1)
                    characterManager.characterAnimation.Walk();
                else
                    characterManager.characterAnimation.Run();
            }
            else
            {
                characterManager.characterAnimation.Wait();

            }

            desiredPosition = transform.position;
            Debug.Log(desiredPosition);
            desiredPosition.z = desiredPosition.z + swipeControls.SwipeDelta.y;
            desiredPosition.y = +0;
            desiredPosition.x = desiredPosition.x + swipeControls.SwipeDelta.x;
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, 8f * Time.deltaTime);
            lookAtTarget = new Vector3(swipeControls.SwipeDelta.x, 0, swipeControls.SwipeDelta.y);
            playerRot = Quaternion.LookRotation(lookAtTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, 50f * Time.deltaTime);

        }
    }
    public bool IsMoving { get { return swipeControls.IsDragging; } }

}
