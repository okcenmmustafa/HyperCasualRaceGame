using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using System.Linq;
using Random = System.Random;

public class AIController : MonoBehaviour
{
    public int targetLevel;
    int targetIndexRandom;
     NavMeshAgent agentOpponent;
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
        if (Vector3.Distance(transform.position, targetPointManager.pointCategorize[targetLevel, targetIndexRandom].transform.position) < 10 && targetLevel < targetPointManager.TargetPoints.Count - 1)
        {
            targetLevel++;
            nextPoint(targetLevel);
        }
    }

    void nextPoint(int targetLevel)
    {
      
            targetIndexRandom = rastgele.Next(targetPointManager.instantiateSize - 1);
            agentOpponent.SetDestination(targetPointManager.pointCategorize[targetLevel, targetIndexRandom].transform.position);
     
    }
    public NavMeshAgent AgentOpponent
    {
        get { return agentOpponent; }
        set { agentOpponent = value; }
    }
}


