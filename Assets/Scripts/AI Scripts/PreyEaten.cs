using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyEaten : MonoBehaviour
{
    public int points = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<Animator>().SetTrigger("Shrink");
            other.gameObject.GetComponent<SturgeonEat>().eatPrey(points);
            Coroutine start = StartCoroutine(toDelete(gameObject));
            transform.localScale.Set(0.1f, 0.1f, 0.1f);
        }
    }

    private IEnumerator toDelete(GameObject me)
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(me);
        yield break;
    }
}
