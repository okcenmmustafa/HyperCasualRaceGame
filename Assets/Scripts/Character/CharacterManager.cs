using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{

    public CharacterController characterController;
    public AIMovement aIMovement;
    public Movement Movement;
    public CharacterAnimation characterAnimation;
    public CharacterCollider characterCollider;
    AIController aIController;
    [HideInInspector] public PlayerInfo playerInfo;
    public GameObject finishLine;
    bool died=false;
    public bool isFinishedTheRace = false;
    public PaintWall PaintableLayer;
    public int AIPercentageRedColor = 0;

    void Awake()
    {
        playerInfo = new PlayerInfo(gameObject.name, 0);
        Movement = GetComponent<Movement>();
        aIMovement = GetComponent<AIMovement>();
        characterAnimation = GetComponent<CharacterAnimation>();
        characterController = GetComponent<CharacterController>();
        characterCollider = GetComponent<CharacterCollider>();
        aIController = GetComponent<AIController>();
    }
    void Update()
    {
        if (died)
        {
            //Debug.Log("Died");
            died = false;
        }else if (isFinishedTheRace)
        {
            //Debug.Log("Finish");
            characterAnimation.Wait();
            if(!!aIController)aIController.AgentOpponent.isStopped=true;
            playerInfo.percantageRedColor = ShowPercentage();

        }
        else { 
        playerInfo.distance = Vector3.Distance(transform.position, finishLine.transform.position);
            
        }
    }
    public void Die()
    {
        died = true;
    }
    public void Finish()
    {
        isFinishedTheRace = true;
    }
    public int ShowPercentage()
    {
        var randomValue = Random.Range(1, 20);
        if (transform.tag.Equals("mainCharacter"))
        {
            return PaintableLayer.percentage;
        }
        else 
        {
            StartCoroutine(AIPercentageRedColorIE(randomValue));
            return AIPercentageRedColor;
        }
        }
   
    IEnumerator AIPercentageRedColorIE(int time)
    {
        Debug.Log(time);
        yield return new WaitForSeconds(time);
        if (AIPercentageRedColor < 100)
            AIPercentageRedColor += 1;

    }
}
