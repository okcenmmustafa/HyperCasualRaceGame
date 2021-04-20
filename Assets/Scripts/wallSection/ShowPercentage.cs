using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowPercentage : MonoBehaviour
{
    public PaintWall wall;
    TextMeshProUGUI textmeshPro;
    private void Start()
    {
         textmeshPro= GetComponent<TextMeshProUGUI>();

    }
    void Update()
    {
        Debug.Log(wall.percentage);
        textmeshPro.text = "The Percentage of Red is " + wall.percentage;
    }
}
