using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    
    private float zOff = 14.63f;

    private float yOff = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        Vector3 newPos = new Vector3( player.position.x, yOff + player.position.y, player.position.z - zOff);
        transform.position = newPos;
    }

    public void setZ(float newNum)
    {
        zOff += newNum;
        yOff += 0.3f * newNum;
    }
}
