using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtterMove : MonoBehaviour
{

    public float speed;
    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y, pos.z + speed * Time.deltaTime);
    }
}
