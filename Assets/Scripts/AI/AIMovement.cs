using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public float rotSpeed = 8;
    public float speed = 8;
    CharacterManager characterManager;
    NavMeshAgent navMeshAgent;
    private void Start()
    {
        characterManager = GetComponent<CharacterManager>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //AI animasyonları
        if (navMeshAgent.velocity.x==0 && navMeshAgent.velocity.z==0)
        {
            characterManager.characterAnimation.Wait();
        }
        else
        {
            characterManager.characterAnimation.Run();
        }
    }
}
