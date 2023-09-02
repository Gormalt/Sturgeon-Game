using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtterSwim : MonoBehaviour, Activateable
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
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            other.gameObject.GetComponent<SturgeonForward>().start = false;
            other.gameObject.GetComponent<SturgeonForward>().pauseMenu.SetActive(true);
            
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
                new Vector3(transform.position.x + xChange * Time.deltaTime, transform.position.y,
                    transform.position.z);
            yield return new WaitForFixedUpdate();
        }

    }
}
