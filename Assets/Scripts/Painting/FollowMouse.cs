using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Canvas myCanvas;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 pos;
        // Brush objesinin Mouse hareketini takip etmesi 
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        transform.position = myCanvas.transform.TransformPoint(pos);
    }
}
