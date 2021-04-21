
using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
     public String name;
     public float distance;
     public bool finished=false;
    public int percantageRedColor;
    public String rank ="";
    public PlayerInfo(String name, float distance)
    {
        this.name = name;
        this.distance = distance;
    }
   
    void Update()
    {

    }
    // Main Character ve AI Rakiplerin yarışmayı yarış bitirmesi 
    public void isFinish()
    {
        finished = true;
    }
  
}