using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    
    public CharacterController characterController;
    public AIMovement aIMovement;
    public Movement Movement;
    public CharacterAnimation characterAnimation;
    public CharacterCollider characterCollider;

    private void Awake()
    {
        Movement = GetComponent<Movement>();
        aIMovement = GetComponent<AIMovement>();
        characterAnimation = GetComponent<CharacterAnimation>();
        characterController = GetComponent<CharacterController>();
        characterCollider = GetComponent<CharacterCollider>();
    }
}
