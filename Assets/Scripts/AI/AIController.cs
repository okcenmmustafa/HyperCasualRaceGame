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
    static Random rnd = new Random();
    public TargetPointManager targetPointManager;
    
    void Start()
    {
         targetIndexRandom = rnd.Next(targetPointManager.instantiateSize - 1);
         agentOpponent = GetComponent<NavMeshAgent>();

    }

    public void StartMovement()
    {
        //Play butonuna basıldıktan sonra AI rakiplerin haraketini başlatır
        AgentOpponent.SetDestination(targetPointManager.pointCategorize[0, targetIndexRandom].transform.position);

    }
    void Update()
    {
        //Target Birsonraki target point kontrolünü sağlar 
        if (Vector3.Distance(transform.position, targetPointManager.pointCategorize[targetLevel, targetIndexRandom].transform.position) < 10 && targetLevel < targetPointManager.TargetPoints.Count - 1)
        {
            targetLevel++;
            nextPoint(targetLevel);
        }
    }

    // AI daha zeki hale getirmek için taget pointler oluşturuldu. Bir sonraki target aynı çizgide oluşturulan target pointlerden birisine random olarak seçerek belirlenir.
    void nextPoint(int targetLevel)
    {
      
            targetIndexRandom = rnd.Next(targetPointManager.instantiateSize - 1);
            agentOpponent.SetDestination(targetPointManager.pointCategorize[targetLevel, targetIndexRandom].transform.position);
     
    }
    public NavMeshAgent AgentOpponent
    {
        get { return agentOpponent; }
        set { agentOpponent = value; }
    }
}


