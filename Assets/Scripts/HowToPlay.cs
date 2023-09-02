using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{

    public GameObject playMenu;
    
    public void howToPlay()
    {
        playMenu.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            playMenu.SetActive(false);
        }
    }
}
