using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDetection : MonoBehaviour
{

    private Vector3 firstPosition;
    private Vector3 lastPosition;


    private float dragDistance;      // minimum distance for swipe

    public Text touchText;

    private void Start()
    {
        dragDistance = Screen.height * 15 / 100;
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                firstPosition = touch.position;
                lastPosition = touch.position;
            }
            else if(touch.phase== TouchPhase.Moved)
            {
                lastPosition = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                lastPosition = touch.position;
                if(Mathf.Abs(lastPosition.x-firstPosition.x)>dragDistance||Mathf.Abs(lastPosition.y-firstPosition.y) > dragDistance)
                {
                    if(Mathf.Abs(lastPosition.x-firstPosition.x) > Mathf.Abs(lastPosition.y-firstPosition.y))
                    {
                        if((lastPosition.x > firstPosition.x))
                        {
                            //Right Swipe
                            touchText.text = "Right Swipe";
                        }

                        else
                        {
                            //Left Swipe
                            touchText.text = "Left Swipe";
                            
                        }
                    }
                    else
                    {
                        if(lastPosition.y > firstPosition.y)
                        {
                            //Top Swipe
                            touchText.text = "Top Swipe";
                        }
                        else
                        {
                            //Down Swipe
                            touchText.text = "Down Swipe";
                        }
                    }
                }
                else
                {
                    //Its a Tap
                    touchText.text = "Just a Tap";
                }
            }
        }
        
    }

}
