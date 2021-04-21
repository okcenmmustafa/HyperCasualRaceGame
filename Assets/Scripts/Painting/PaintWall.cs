using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PaintWall : MonoBehaviour
{
   
    public Color drawColor = Color.red;
    Texture2D texWall;
    Vector2 mousePos = new Vector2();
    RectTransform rect;
    int height = 0;
    int width = 0;
    int radius = 100;
    int x = 200;
    int y=0;
    int total = 0;
    private int percantageRed = 0;
    void Start()
    {
        var wall = gameObject.GetComponent<RawImage>();
        rect = wall.GetComponent<RectTransform>();
        width =(int) rect.rect.width;
        height = (int) rect.rect.height;
        x =(int) rect.rect.x;
        y = (int)rect.rect.y;
        texWall = wall.texture as Texture2D;
        var pixelData = texWall.GetPixels();
        total = pixelData.Length;
        drawColor.a= 0.42f;

    }

    // Update is called once per frame
    void Update() 
    {
        // Mouse pozisyon bilgisinin alınması
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, Input.mousePosition, Camera.main, out mousePos);

        // Duvarın 0,0 noktasından başlamak için gerekli kodlar
        mousePos.x = width - (width / 2 - mousePos.x);
        mousePos.y = Mathf.Abs((height / 2 - mousePos.y) - height);

        // Mouse Tıkladığında Boyama yapılması 
        if (Input.GetMouseButton(0))
        {
            if(mousePos.x>-1 && mousePos.y > -1)
            {
                // Brush Boyunun ayarlanması
                for (int y = -radius; y <= radius; y++)
                    for (int x = -radius; x <= radius; x++)
                        if (x * x + y * y <= radius * radius)
                texWall.SetPixel((int)mousePos.x + (int)x, (int)mousePos.y + (int)y, new Color(drawColor.r, drawColor.g, drawColor.b));

                }
            // Piksellerden kırmızı içeren piksellerin sayısının tüm piksellerin sayısına oranı %lik oarak çevirilmesi
            percantageRed = (int)Math.Round((double)(100 * calculateRedPixels()) / total);
            
            texWall.Apply();

        }
        


    }

    //Kırmızı Piksellerin sayısının bulunması
     int calculateRedPixels()
    {
        var colorIndex = new List<Color>();
        var redPixels = 0;
        var pixelData = texWall.GetPixels();

        for (var i = 0; i < total; i++)
        {
            var color = pixelData[i];

            if (color.r==1)
            {
                redPixels++;
            }
        }
        
        return redPixels;
    }
    public int percentage
    {
        get
        {
            return percantageRed;
        }
        set
        {
            percantageRed = value;
        }
    }
} 
    
    
