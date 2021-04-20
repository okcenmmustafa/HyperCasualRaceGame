using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = System.Random;

public class RankSystem : MonoBehaviour
{
   
    public List<GameObject> players;
    public GameObject RankRow;
    public GameObject PercantageBar;
    TextMeshProUGUI prefabTextMesh;
    GameObject[] RankListUI; 
    String RankList;
    List<PlayerInfo> playersInfo;
    public PaintWall PaintableLayer;
     int rank = 0;
    void Start()
    {
        playersInfo = new List<PlayerInfo>();
          foreach (GameObject player in players)
            {
            playersInfo.Add(player.GetComponent<CharacterManager>().playerInfo);
            }
        RankListUI = new GameObject[players.Count];
        for (var i = 0; i < playersInfo.Count; i++)
        {
            var myNewRankRow = Instantiate(RankRow, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - (30 * i)), Quaternion.identity);
            myNewRankRow.transform.parent = gameObject.transform;
            var PercantageShow = Instantiate(PercantageBar, new Vector2(gameObject.transform.position.x + 120, gameObject.transform.position.y - (30 * i)), Quaternion.identity);
            PercantageShow.transform.parent = myNewRankRow.transform;
            RankListUI[i] = myNewRankRow;

        }
    }

    // Update is called once per frame
    void Update()
    {
        Rank(playersInfo);

    }
    void Rank(List<PlayerInfo> playersInfo)
    {
        var orderByResult = from p in playersInfo
                            orderby p.distance  
                            select p;

        foreach (var item in orderByResult.Select((value, i) => new { i, value })) {
            var value = item.value;
            var position = item.i+1;
            if (value.finished && value.rank.Equals(""))
            {
                value.distance = (float)(position * 0.1);
                RankListUI[position - 1].transform.GetComponentInChildren<Text>().enabled=true;
                RankListUI[position - 1].transform.GetComponentInChildren<Text>().text =value.percantageRedColor.ToString();

            }
            if (value.percantageRedColor == 100 && value.rank.Equals(""))
            {
                Debug.Log(value.percantageRedColor);
                value.rank = RankQue();
                RankListUI[position - 1].transform.GetComponentInChildren<Text>().text = value.rank;
            }
            String positionUIFix = position < 10 ? " " + position : ""+ position;
            var rankString =  positionUIFix +"    " + value.name;
            RankListUI[position-1].transform.GetComponentInChildren<TextMeshProUGUI>().SetText(rankString);

        }
    }

    String RankQue()
    {
        rank++;
        if (rank == 1)
        {
            return "Winner";
        }
        else if (rank == 2)
        {
            return "Second";
        }
        else if (rank == 3)
        {
            return "Third";
        }
        else
        {
            return rank + "rd";
        }

    }


}
