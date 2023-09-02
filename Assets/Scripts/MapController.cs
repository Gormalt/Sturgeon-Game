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
    public GameObject trees;
    public float activeDis = 70f;
    public float zChange;
    public GameObject[] preditors;
    private float startZPos = 0;
    private int setNum = 0;

    public bool title = false;
    //@TODO consider refactoring to a queue of lists
    private Queue<GameObject> envSets = new Queue<GameObject>();
    
    Queue<Tuple<float, Activateable>> activeQueue = new Queue<Tuple<float, Activateable>>();

    private Queue<GameObject> treeSets = new Queue<GameObject>();
    
    //The function for checking on current enemies and seeing if they need to start moving.
    //@TODO Change to private, have one method of checking threshhold/activeQueue
    public void checkActiveQueue(float zPos)
    {
        Activateable potential;
        
        while (activeQueue.Count > 0 && activeQueue.Peek().Item1 <= zPos + activeDis)
        {
            potential = activeQueue.Dequeue().Item2;
            potential.activateNow();
        }
    }
    //@TODO check and see if we need to spawn more map.
    //Currently setup for testing;
    public void checkThreshold(float zPos)
    {
        if (zPos > zChange * (setNum - 10))
        {
            spawnMoreMap();
        }
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
        if (setNum > 12 && title)
        {
            return;
        }
        setNum = setNum + 1;
        GameObject thisSet = Instantiate(mapPrefab, new Vector3(0, 0, startZPos + (zChange * setNum)), Quaternion.identity);
        
        //@Todo add cool spawning rules for different prey
        float preyZ = startZPos + 66 + (zChange * setNum);
        
       
        int randNo = UnityEngine.Random.Range(1, 4);

        while (randNo > 0)
        {
            float randX = UnityEngine.Random.Range(-26.0f, 26.0f);
            float randY = UnityEngine.Random.Range(-6.5f, 4.5f);

            Quaternion rot;
            
            if (randNo == 2)
            {

                float predX = UnityEngine.Random.Range(-26.0f, 26.0f);
                float predY = UnityEngine.Random.Range(-6.5f, 4.5f);

                Vector3 predPos;
                predPos = new Vector3(predX, predY, preyZ + (randNo * 30f));
                
                if (predX > 0)
                {
                    rot = Quaternion.Euler(0, -100f, 0);
                }
                else
                {
                    rot = Quaternion.Euler(0, 99f, 0);
                }

                int ranPred;
                if (UnityEngine.Random.Range(0, 4) == 3)
                {
                    ranPred = 1;
                    
                    if (predX < 0)
                    {
                        rot = Quaternion.Euler(0, -100f, 0);
                    }
                    else
                    {
                        rot = Quaternion.Euler(0, 99f, 0);
                    }
                }
                else
                {
                    ranPred = 0;
                }
                //Heavy line... enqueues a pred object into the listening queue while instantiating it as a child of this envSet
                activeQueue.Enqueue(new Tuple<float, Activateable>(preyZ,
                    Instantiate(preditors[ranPred], predPos, rot, thisSet.transform)
                        .GetComponent<Activateable>()));
            }

            Vector3 preyPos;

            preyPos = new Vector3(randX, randY, preyZ + (randNo * 30f));
            

            if (randX < 0)
            {
                rot = Quaternion.Euler(0, 90f, -51f);
            }
            else
            {
                rot = Quaternion.Euler(0, 270.0f, 72.6f);
            }
            

            activeQueue.Enqueue(new Tuple<float, Activateable>(preyZ,
                Instantiate(preys[0], preyPos, rot, thisSet.transform)
                    .GetComponent<Activateable>()));
            
            randNo--;
        }

        if (setNum % 7 == 0)
        {
            treeSets.Enqueue(Instantiate(trees, new Vector3(618f, 341f, (zChange * setNum)), Quaternion.identity));
            if (treeSets.Count > 5)
            {
                Destroy(treeSets.Dequeue());
            }
        }
        
        //Adds it to the environment queue, checks the length, takes out the oldest element.
        envSets.Enqueue(thisSet);
        if (envSets.Count > 13)
        {
            Destroy(envSets.Dequeue());
        }
    }
}
