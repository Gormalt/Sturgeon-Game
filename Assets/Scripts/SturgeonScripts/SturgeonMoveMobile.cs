using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SturgeonMoveMobile : MonoBehaviour
{
    
    
    private Vector2 fp;   //First touch position
    private Vector2 lp;   //Last touch position

    private float difX;
    private float difY;

    private float newXPos;
    private float newYPos;
    
    public float sensitivity;

    public SturgeonForward forw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount == 1)
        {
            difX = 0;
            difY = 0;
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            { 
                fp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                difX = touch.position.x - fp.x;
                difY = touch.position.y - fp.y;

                fp = touch.position;
            }

            forw.xMove = (difX * sensitivity);
            forw.yMove = (difY * sensitivity);
            
        }
        
/*
        Vector3 curPos = transform.position;     

        if (newXPos < -33f || newXPos > 33f)
        {
            newXPos = transform.position.x;
        }
        else
        {
            
            newXPos = curPos.x + (difX/sensitivity) ;
        }

        if (newYPos < -6.5f || newYPos > 7.63f)
        {
            newYPos = transform.position.y;
        }
        else
        {
            newYPos = curPos.y + (difY / sensitivity) ;
        }
    
*/
        //       Vector3 newPos = new Vector3(newXPos, newYPos, curPos.z);
//        transform.position = newPos;

        
        
    }
}
