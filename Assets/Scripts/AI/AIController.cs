using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using System.Linq;
using Random = System.Random;

public class AIController : MonoBehaviour
{
    int targetLevel, targetIndexRandom;
     NavMeshAgent AgentOpponent;
    static Random rastgele= new Random();
    public TargetPointManager targetPointManager;
    void Start()
    {
         targetIndexRandom = rastgele.Next(targetPointManager.instantiateSize - 1);
        AgentOpponent = GetComponent<NavMeshAgent>();
        AgentOpponent.SetDestination(targetPointManager.pointCategorize[0, targetIndexRandom].transform.position);

    }

    void Update()
    {

        if (Vector3.Distance(transform.position,targetPointManager.pointCategorize[targetLevel, targetIndexRandom].transform.position)<3)
        {
            targetLevel++;
            nextPoint(targetLevel);
            Debug.Log("Girdi" + targetIndexRandom);
        }
    }

    void nextPoint(int targetLevel)
    {
        if (targetLevel == 0)
        {
            targetIndexRandom = rastgele.Next(targetPointManager.instantiateSize - 1);
            AgentOpponent.SetDestination(targetPointManager.pointCategorize[0, targetIndexRandom].transform.position);
        }
        if (targetLevel == 1)
        {
            targetIndexRandom = rastgele.Next(targetPointManager.instantiateSize - 1);
            AgentOpponent.SetDestination(targetPointManager.pointCategorize[1, targetIndexRandom].transform.position);
        }
        if (targetLevel == 2)
        {
            targetIndexRandom = rastgele.Next(targetPointManager.instantiateSize - 1);
            AgentOpponent.SetDestination(targetPointManager.pointCategorize[2, targetIndexRandom].transform.position);
        }
        if (targetLevel == 3)
        {
            targetIndexRandom = rastgele.Next(targetPointManager.instantiateSize - 1);
            AgentOpponent.SetDestination(targetPointManager.pointCategorize[3, targetIndexRandom].transform.position);
        }
        if (targetLevel == 4)
        {
            targetIndexRandom = rastgele.Next(targetPointManager.instantiateSize - 1);
            AgentOpponent.SetDestination(targetPointManager.pointCategorize[4, targetIndexRandom].transform.position);
        }
    }
}


