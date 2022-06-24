using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapController: MonoBehaviour
{
    //@TODO Allow it to randomize map generation?
    public GameObject mapPrefab;
    public GameObject[] preys;
    public float zChange;

    private float startZPos = 0;
    private int setNum = 0;
    //@TODO consider refactoring to a queue of lists
    private Queue<GameObject> envSets = new Queue<GameObject>();
    
    Queue<Tuple<float, Activateable>> activeQueue = new Queue<Tuple<float, Activateable>>();
    //The function for checking on current enemies and seeing if they need to start moving.
    private void checkActiveQueue(float zPos)
    {
        Activateable potential;
        
        while (activeQueue.Count > 0 && activeQueue.Peek().Item1 <= zPos)
        {
            potential = activeQueue.Dequeue().Item2;
            potential.activateNow();
        }
    }
    //@TODO check and see if we need to spawn more map.
    //Currently setup for testing;
    public void checkThreshold()
    {
        spawnMoreMap();
    }
    
    //Lets you start the map at a specific zpos and setNum (usually 0)
    public void startMapAt(float zPos, int setStart=0)
    {
        startZPos = zPos;
        setNum = setStart;
    }
    
    //@TODO add activatables randomly
    //Adds more map in front of player
    private void spawnMoreMap()
    {
        setNum = setNum + 1;
        GameObject thisSet = Instantiate(mapPrefab, new Vector3(0, 0, startZPos + (zChange * setNum)), Quaternion.identity);
        //@Todo add cool spawning rules for different prey
        float preyX = startZPos + 66 + (zChange * setNum);
        //Heavy line... enqueues a prey object into the listening queue while instantiating it as a child of this envSet
        activeQueue.Enqueue(new Tuple<float, Activateable>(preyX, 
            Instantiate(preys[0], new Vector3(-25, 1.8f, preyX), Quaternion.identity, thisSet.transform).GetComponent<Activateable>()));

        //Adds it to the environment queue, checks the length, takes out the oldest element.
        envSets.Enqueue(thisSet);
        if (envSets.Count > 11)
        {
            Destroy(envSets.Dequeue());
        }
    }
}
