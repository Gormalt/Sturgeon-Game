using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SturgeonForward : MonoBehaviour
{
    //We set the speed in the unity inspector
    public float speed;

    public Transform transform;
    
    // Start is called before the first frame update
    void Start()
    {
        //Set the position to 0
    }

    // Update is called once per frame
    void Update()
    {
        
        //Get the current position
        Vector3 curPos = transform.position;
        //Make new position using the current position + speed
        Vector3 newPos = new Vector3(curPos.x, curPos.y, curPos.z + speed);
        //Set that new position onto the strugreon
        transform.position = newPos;
        
    }
}
