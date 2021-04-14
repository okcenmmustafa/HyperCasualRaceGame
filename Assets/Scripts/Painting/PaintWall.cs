using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PaintWall : MonoBehaviour
{
    Texture2D texWall;
    Vector2 mousePos = new Vector2();
    RectTransform rect;

    void Start()
    {
        var wall = gameObject.GetComponent<RawImage>();
        rect = wall.GetComponent<RectTransform>();
        texWall = wall.texture as Texture2D;
        var pixelData = texWall.GetPixels();
        print("Total pixels " + pixelData.Length);
  

    }

    // Update is called once per frame
    void Update() 
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, Input.mousePosition, Camera.main, out mousePos);
        print("Mouse " + mousePos.x + "," + mousePos.y);
    }
}
