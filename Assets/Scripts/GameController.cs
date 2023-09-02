using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public MapController mapCntrl;

    public Transform player;
    private
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            mapCntrl.checkThreshold(player.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        mapCntrl.checkThreshold(player.position.z);
        mapCntrl.checkActiveQueue(player.position.z);
    }
    
 
}
