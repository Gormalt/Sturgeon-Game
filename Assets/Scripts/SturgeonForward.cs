using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SturgeonForward : MonoBehaviour
{

    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        //Set the position to 0
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = transform.position;
        Vector3 newPos = new Vector3(curPos.x, curPos.y, curPos.z + speed);
        transform.position = newPos;
    }
}
