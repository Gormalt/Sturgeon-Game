using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, player.position.z - 14.63f);
        transform.position = newPos;
    }
}
