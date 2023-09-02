using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DamselflyMove : MonoBehaviour, Activateable
{
    public float xChange;

    private bool active;
    
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x > 0)
        {
            xChange = -xChange;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool activateNow()
    {
        Coroutine start = StartCoroutine(startMovement());
        return true;
    }
    
    private IEnumerator startMovement()
    {
        for (;;)
        {
            transform.position =
                new Vector3(transform.position.x + (xChange * Time.deltaTime), transform.position.y, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        
    }
}
