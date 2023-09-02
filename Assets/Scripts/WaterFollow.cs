using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFollow : MonoBehaviour
{
    public Transform cameraTransform;

    public Vector3 offset = new Vector3(-2.1f,-1.784317f, 65.6f);
    // Update is called once per frame
    void Update()   
    {
        Vector3 pos = cameraTransform.position;
        transform.position = new Vector3(offset.x, offset.y, pos.z + offset.z);
    }
}
