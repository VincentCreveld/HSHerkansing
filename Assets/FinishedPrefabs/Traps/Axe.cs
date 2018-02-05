using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    //startPosition: used to determine how far the axe should go together with difference
    //currentGoal: Where the axe should head towards for now
    public Vector3 swingEnd, swingStart, difference;
    Vector3 currentGoal;
    public float swingTotalLength;

    //swingTime: the time the axe should take to complete one sweep
    //speed: the speed the axe needs to complete the sweep in aforementioned time
    public float swingTime;
    float speed;

    //forwards: used to determine which direction the axe is going
    bool forwards;


    public void Prepare()
    {
        swingEnd = transform.position - difference;
        swingStart = transform.position + difference;
        swingTotalLength = Vector3.Distance(swingEnd, swingStart);

        speed = swingTotalLength / swingTime;
        forwards = true;
        DetermineGoal();
    }
   
    // Update is called once per frame
    void Update()
    {
        //Once the axe has arrive at its goal, change up the goal.
        if (transform.position == currentGoal)
            DetermineGoal();
        
        transform.position = Vector3.MoveTowards(transform.position, currentGoal, speed * Time.deltaTime);
    }

    //Determines where the axe should go and how it should rotate.
    void DetermineGoal()
    {
        forwards = !forwards;
        if (forwards)
            currentGoal = swingEnd;
        else
            currentGoal = swingStart;
    }

    public void Reset()
    {
        transform.position = Vector3.Lerp(swingEnd, swingStart, 0.5f);
        this.enabled = false;
    }
}