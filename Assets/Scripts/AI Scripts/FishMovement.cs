using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour, Activateable
{
    public float xChange;
    private bool active;

    public int size;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x > 0)
        {
            xChange = -xChange;
        }
        size = UnityEngine.Random.Range(1, 3);
        transform.localScale = new Vector3(size, size, (float) size/2f);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (size*2 > other.gameObject.GetComponent<SturgeonEat>().level)
            {
                other.gameObject.GetComponent<SturgeonForward>().start = false;
                other.gameObject.GetComponent<SturgeonForward>().pauseMenu.SetActive(true);
            }
            else
            {
                Coroutine small = StartCoroutine(shrink());
            }
        }
    }
    // Update is called once per frame
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
                new Vector3(transform.position.x + xChange * Time.deltaTime, transform.position.y, transform.position.z);
            yield return new WaitForFixedUpdate();
        }
        
    }

    private IEnumerator shrink()
    {
        float size = 1;
        for (;;)
        {
            size = size - ((size) * 10f * Time.deltaTime);
            if (size < 0)
            {
                size = 0;
            }
            transform.localScale = new Vector3(size, size, size/2f);
            yield return new WaitForEndOfFrame();  
        }
    }
}
