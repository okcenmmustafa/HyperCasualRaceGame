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
    public Sprite[] RankSprites;
    public List<GameObject> players;
    public GameObject RankRow;
    public GameObject PercantageBar;
    public bool gameOver = false;
    GameObject[] RankListUI; 
    public List<PlayerInfo> playersInfo;
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

        //Rank sistemi için gerekli prefabların instantiate edilip gerekli yerlere yerleştirilmesi
        for (var i = 0; i < playersInfo.Count; i++)
        {
            var myNewRankRow = Instantiate(RankRow, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - (60 * i)), Quaternion.identity);
            myNewRankRow.transform.parent = gameObject.transform;
            var PercantageShow = Instantiate(PercantageBar, new Vector2(gameObject.transform.position.x + 230, gameObject.transform.position.y - (60 * i)), Quaternion.identity);
            PercantageShow.transform.parent = myNewRankRow.transform;
            RankListUI[i] = myNewRankRow;

        }
    }

    void Update()
    {
        if (rank <= 10) { 
        Rank(playersInfo);
        }
        else
        {
            gameOver = true;

        }

    }
    void Rank(List<PlayerInfo> playersInfo)
    { 

        // Main Character ve AI rakiplerin Bitiş noktasına olan uzaklıkları karşılaştırılarak sıralanır.
        var orderByResult = from p in playersInfo
                            orderby p.distance  
                            select p;

        foreach (var item in orderByResult.Select((value, i) => new { i, value })) {
            var value = item.value;
            var position = item.i+1;
            // Parkur yarışını bitiren yarışmacı buraya girecektir.
            if (value.finished && value.rank.Equals(""))
            {
                // distance position*0.1 yapılarak yarışı bitirdikten sonra birdaha distance hesaplanarak sıralama bozulmaması sağlandı. 
                value.distance = (float)(position * 0.1);

                //----- Yarış bittikten sonra Duvar boyama Rank List  UI ayarları  ----- //
                RankListUI[position - 1].transform.GetChild(2).GetChild(1).GetComponentInChildren<TextMeshProUGUI>().enabled=true;
                RankListUI[position - 1].transform.GetChild(2).GetChild(0).GetComponent<Image>().enabled = true;
                RankListUI[position - 1].transform.GetChild(2).GetChild(1).GetComponentInChildren<TextMeshProUGUI>().SetText(value.percantageRedColor.ToString());
                RankListUI[position - 1].transform.GetChild(2).GetChild(0).GetComponent<PercentageBar>().current = value.percantageRedColor;
                //-----  Yarış bittikten sonra Duvar boyama Rank List UI ayarları  ----- //

            }
            // Duvar boyamayı bitiren yarışmacı bu bölüme girecektir.
            if (value.percantageRedColor == 100 && value.rank.Equals(""))
            {
                //-----  Duvar Boyama da bittikten sonra Kazananı ve sıralamayı belirlemek için Rank List UI ayarları  ----- //

                value.rank = RankQue();

                // İlk üç için texture kullanıldı bu sebeple rank <= 3 ise bu bölüme girer
                if (rank <= 3) { 
                    RankListUI[position - 1].transform.GetChild(2).GetChild(1).GetComponentInChildren<TextMeshProUGUI>().enabled = false;
                    RankListUI[position - 1].transform.GetChild(2).GetChild(2).GetComponent<Image>().sprite = RankSprites[rank - 1];
                    RankListUI[position - 1].transform.GetChild(2).GetChild(2).GetComponent<Image>().enabled = true;
                }
                else
                {
                    RankListUI[position - 1].transform.GetChild(2).GetChild(1).GetComponent<Image>().enabled = true;
                    RankListUI[position - 1].transform.GetChild(2).GetChild(1).GetComponentInChildren<TextMeshProUGUI>().SetText(value.rank);

                }
                RankListUI[position - 1].transform.GetChild(2).GetChild(0).GetComponent<Image>().enabled = false;
                RankListUI[position - 1].transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
             
                //-----  Duvar Boyama da bittikten sonra Kazananı ve sıralamayı belirlemek için Rank List UI ayarları  ----- //

            }

            //----- Her bölümde değişmesi gereken RankList UI ayarlamaları ---- //
            String positionUIFix = position < 10 ? " " + position : ""+ position;
            var rankString =  positionUIFix +"    " + value.name;
            RankListUI[position-1].transform.GetComponentInChildren<TextMeshProUGUI>().SetText(rankString);
            //----- Her bölümde değişmesi gereken RankList UI ayarlamaları ---- //

        }
    }
    // Sıralamaların String olarak gönderilmesi
    String RankQue()
    {
        rank++;
        if (rank == 1)
        {
            return "1st";
        }
        else if (rank == 2)
        {
            return "2nd";
        }
        else if (rank == 3)
        {
            return "3rd";
        }
        else
        {
            return rank + "th";
        }

    }


}
