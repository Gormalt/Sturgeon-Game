using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SturgeonMove : MonoBehaviour
{
    //Notice there is a duplicate of this file for touch screen, this one is for keyboard movement.
    private Vector2 fp;   //First touch position
    private Vector2 lp;   //Last touch position

    public SturgeonForward forw;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float inX = Input.GetAxis("Horizontal");
        float inY = Input.GetAxis("Vertical");


        Vector3 curPos = transform.position;
        
        float newXPos = curPos.x + (speed*inX* Time.deltaTime);
        float newYPos = curPos.y + (speed * inY * Time.deltaTime);

        if (newXPos < -33f || newXPos > 33f)
        {
            newXPos = transform.position.x;
        }

        if (newYPos < -6.5f || newYPos > 7.63f)
        {
            newYPos = transform.position.y;
        }

        if (forw.start)
        {
            Vector3 newPos = new Vector3(newXPos, newYPos, curPos.z);
            transform.position = newPos;

        }

        
    }
}
