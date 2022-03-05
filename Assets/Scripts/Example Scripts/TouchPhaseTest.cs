using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPhaseTest : MonoBehaviour
{
    //Determines what phase the touch is in and prints it to the console.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch.phase);
    
        }
    }
}
