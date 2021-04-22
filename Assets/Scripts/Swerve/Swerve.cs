using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swerve : MonoBehaviour
{
    private bool isDragging=false;
    private  bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 startTouch, swipeDelta;
   
    private void Update()
    {

        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;
        swipeDelta = Vector2.zero;
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            swipeDelta = Vector2.zero;

            //Reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                swipeDelta = Vector2.zero;

                //Reset();

            }
        }
            #endregion
            // Tıklama ve bırakma noktası arasındaki mesafe hesabı
            swipeDelta = Vector2.zero;
            if(isDragging)
            {
                if (Input.touches.Length > 0)
                {
                    swipeDelta = Input.touches[0].position - startTouch;
                }
                else if (Input.GetMouseButton(0))
                {
                    swipeDelta = (Vector2)Input.mousePosition - startTouch;
                }

            }
            

    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool IsDragging { get { return isDragging; } }


}
