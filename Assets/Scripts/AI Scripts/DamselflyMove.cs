using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamselflyMove : MonoBehaviour, Activateable
{
    public float xChange;

    private bool active;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
                new Vector3(transform.position.x + xChange, transform.position.y, transform.position.x);
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
