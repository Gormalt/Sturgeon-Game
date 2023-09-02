using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SturgeonEat : MonoBehaviour
{
    private Animator m_animator;

    public CameraFollow cam;
    public GrowthUI ui;
    private int foodLvl;
    
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        foodLvl = 0;
        ui.growTo(foodLvl);
        ui.levelTo(level);
        m_animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    //Val is some eating value
    public void eatPrey(int val)
    {
        foodLvl++;
        if (foodLvl > 6)
        {
            if (level < 4)
            {
                level++;
                growSize(level);
                ui.levelTo(level);

            }

            foodLvl = 0;
        }
        m_animator.SetTrigger("Bite");
        ui.growTo(foodLvl);
    }

    private void growSize(int lvl)
    {
        Coroutine start = StartCoroutine(growSlow(lvl));
        //transform.localScale = new Vector3((float) lvl, (float) lvl, (float) lvl);
       // m_animator.SetInteger("Grow", level);
 
    }

    private IEnumerator growSlow(int amount)
    {
        float grow = 0;
        float addAmm = 0;
        while (grow < 0.5)
        {

            grow += (0.1f) * Time.deltaTime;
            transform.localScale = new Vector3( (level*0.5f) + grow,  (level*0.5f) + grow, + (level*0.5f) + grow);
            cam.setZ(Time.deltaTime * 0.5f);
            yield return new WaitForEndOfFrame();    
        }
        
        yield return null;
    }
}
