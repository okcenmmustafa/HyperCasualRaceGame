using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public GameObject finishLine, spawnPoint;
    public ParticleSystem DeadPartical;
    public CharacterController characterController;
    public AIMovement aIMovement;
    public CharacterAnimation characterAnimation;
    public CharacterCollider characterCollider;
    public AIController aIController;
    [HideInInspector] public PlayerInfo playerInfo;
    public PaintWall PaintableLayer;
    public int AIPercentageRedColor = 0;
    public bool isFinishedTheRace = false,isPressedPlay=false, died = false;
    public AudioSource RunnigSound;
    public AudioSource DiedSound;
    public AudioSource VictorySound;

    void Awake()
    {
        playerInfo = new PlayerInfo(gameObject.name, 0);
        aIMovement = GetComponent<AIMovement>();
        characterAnimation = GetComponent<CharacterAnimation>();
        characterController = GetComponent<CharacterController>();
        characterCollider = GetComponent<CharacterCollider>();
        aIController = GetComponent<AIController>();
    }
    private void Start()
    {

    }
    void Update()
    {
        if (died)
        {
            DiedSound.Play();
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

    //Play butuna basınca AI rakiplerin ve main Characterin hareket izni
    public void CharactersMovementStart()
    {
        if (!!aIController) aIController.StartMovement();
        isPressedPlay = true;
    }


    public void Die()
    {
        died = true;
    }
    public void Finish()
    {
        isFinishedTheRace = true;
    }

    //Duvar boyama bölümünde Main Character ve AI rakiplerin yüzdelikleri
    public int ShowPercentage()
    {
      

        var randomValue = Random.Range(1, 20);
        if (transform.tag.Equals("mainCharacter"))
        {
            if (PaintableLayer.percentage == 100 && playerInfo.rank.Equals("1st"))
            {
                VictorySound.Play();
                playerInfo.rank ="Winner";

            }
            return PaintableLayer.percentage;
        }
        else 
        {
            if(AIPercentageRedColor == 100 && playerInfo.rank.Equals("1st"))
            {
                VictorySound.Play();
                playerInfo.rank = "Winner";
            }
            StartCoroutine(AIPercentageRedColorIE(randomValue));
            return AIPercentageRedColor;
        }
        }
   
    //AI rakipler için random olarak belirlenen hızda artış
    IEnumerator AIPercentageRedColorIE(int time)
    {
        yield return new WaitForSeconds(time);
        if (AIPercentageRedColor < 100)
            AIPercentageRedColor += 1;

    }
}
