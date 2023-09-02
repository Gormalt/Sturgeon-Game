using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SturgeonForward : MonoBehaviour
{
    //We set the speed in the unity inspector
    public float speed;
    public bool start = false;
    public Transform transform;

    public GameObject pauseMenu;

    public float xMove = 0;

    public float yMove = 0;

    private float newXPos;

    private float newYPos;
    // Start is called before the first frame update
    void Start()
    {
        //Set the position to 0
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            //Get the current position
            Vector3 curPos = transform.position;

            newXPos = curPos.x + xMove;
            newYPos = curPos.y + yMove;
            
            if (newXPos < -33f || newXPos > 33f)
            {
                newXPos = curPos.x;
            }

            if (newYPos < -6f || newYPos > 7.63f)
            {
                newYPos = curPos.y;
            }

            
            //Make new position using the current position + speed
            Vector3 newPos = new Vector3( newXPos, newYPos, curPos.z + speed * Time.deltaTime);
            //Set that new position onto the strugreon
            transform.position = newPos;
        }
    }
}
