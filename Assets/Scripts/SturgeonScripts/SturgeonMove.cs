using System.Collections;
using System.Collections.Generic;
using UnityEditor.AdaptivePerformance.Editor;
using UnityEngine;

public class SturgeonMove : MonoBehaviour
{
    private Vector2 fp;   //First touch position
    private Vector2 lp;   //Last touch position

    private float difX;
    private float difY;

    public float sensitivity;
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

            
                
         }
        Vector3 curPos = transform.position;
        Vector3 newPos = new Vector3(curPos.x + (difX/sensitivity), curPos.y + (difY/sensitivity), curPos.z);

        transform.position = newPos;
        
    }
}
